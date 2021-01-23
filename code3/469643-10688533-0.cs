    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Dynamic;
    
    
    namespace SimpleTest {
        public class MyCreateBinder : CreateInstanceBinder {
            public MyCreateBinder(CallInfo info) : base(info) { }
    
            public override DynamicMetaObject FallbackCreateInstance(
                                            DynamicMetaObject target,
                                            DynamicMetaObject[] args,
                                            DynamicMetaObject errorSuggestion) {
                var param = args[0].Value;
    
                Type toCreate = target.Value as Type;
                var ctors = toCreate.GetConstructors()
                            .Where(c => c.GetParameters().Length == args.Length)
                            .ToArray();
    
                if (ctors.Length == 0)
                    throw 
                        new Exception(
                          String.Format(
                          "Can not find constructor for '{0}' with {1} parameters",
                          toCreate, args.Length));
                ConstructorInfo ctorToUse = ctors[0];
                return new DynamicMetaObject(
                                Expression.New(
                                    ctorToUse,
                                    args.Select(a => a.Expression).ToList()),
                           BindingRestrictions.Empty);
            }
        }
    
        public class MySetMemberBinder : SetMemberBinder {
    
            public MySetMemberBinder(string name) : base(name, false) { }
    
            public override DynamicMetaObject FallbackSetMember(
                                    DynamicMetaObject target,
                                    DynamicMetaObject value,
                                    DynamicMetaObject errorSuggestion) {
    
                throw new NotImplementedException();
            }
        }
    
        public class MyGetMemberBinder : GetMemberBinder {
            public MyGetMemberBinder(string name) : base(name, false) { }
    
            public override DynamicMetaObject FallbackGetMember(
                                            DynamicMetaObject target,
                                            DynamicMetaObject errorSuggestion) {
                throw new NotImplementedException();
            }
        }
    
        public class MyInvokeMemberBinder : InvokeMemberBinder {
            public MyInvokeMemberBinder(string name, CallInfo callInfo) 
                : base(name, false, callInfo) { }
    
            public override DynamicMetaObject FallbackInvokeMember(
                                        DynamicMetaObject target,
                                        DynamicMetaObject[] args,
                                        DynamicMetaObject errorSuggestion) {
                var a = this;
                throw new NotImplementedException();
            }
    
            public override DynamicMetaObject FallbackInvoke(
                                        DynamicMetaObject target,
                                        DynamicMetaObject[] args,
                                        DynamicMetaObject errorSuggestion) {
                throw new NotImplementedException();
            }
        }
    
        public class LambdaWrapper : IDynamicMetaObjectProvider {
            private Delegate compiledLambda;
            private LambdaExpression exp;
    
            public LambdaWrapper(LambdaExpression exp) {
                this.exp = exp;
                this.compiledLambda = exp.Compile();
            }
            public dynamic Execute(dynamic param) {
                return compiledLambda.DynamicInvoke(param);
            }
    
            public DynamicMetaObject GetMetaObject(Expression parameter) {
                return new MetaLambdaWrapper(parameter, this);
            }
        }
    
        public class MetaLambdaWrapper : DynamicMetaObject {
            public MetaLambdaWrapper(Expression parameter, object value) : 
                base(parameter, BindingRestrictions.Empty, value) { }
    
            public override DynamicMetaObject BindInvokeMember(
                                        InvokeMemberBinder binder,
                                        DynamicMetaObject[] args) {
                MethodInfo method = this.Value.GetType().GetMethod(binder.Name);
                return new DynamicMetaObject(
                            Expression.Call(
                                Expression.Constant(this.Value),
                                    method,
                                        args.Select(a => a.Expression)),
                            BindingRestrictions.GetTypeRestriction(
                                this.Expression, 
                                typeof(LambdaWrapper)));
            }
        }
    
    
        public class ForSO {
            public ParameterExpression Param;
            public LambdaExpression GetOuterLambda() {
                Expression wrapper;
                IList<Expression> lambdaBody = new List<Expression>();
                Param = Expression.Parameter(typeof(object), "Param");
                lambdaBody.Add(Expression.Assign(
                                Param,
                                Expression.Constant("Value of 'param' variable"))
                              );
                lambdaBody.Add(Expression.Call(
                                null,
                                typeof(ForSO).GetMethod("Write"),
                                Param)
                              );
    
                wrapper = Expression.Dynamic(
                                    new MyCreateBinder(new CallInfo(1)),
                                    typeof(object),
                                    Expression.Constant(typeof(LambdaWrapper)),
                                    Expression.Quote(GetInnerLambda()));
    
    
                lambdaBody.Add(
                    Expression.Dynamic(
                        new MyInvokeMemberBinder("Execute", new CallInfo(1)),
                        typeof(object),
                        wrapper,
                    Expression.Constant("calling inner lambda from outer")));
    
                lambdaBody.Add(wrapper);
    
                return Expression.Lambda(
                            Expression.Block(
                                    new ParameterExpression[] { Param },
                                    lambdaBody));
            }
    
            public LambdaExpression GetInnerLambda() {
                ParameterExpression innerParam = Expression.Parameter(
                                                    typeof(object), 
                                                    "innerParam");
                return Expression.Lambda(
                        Expression.Block(
                            Expression.Call(null,
                                    typeof(ForSO).GetMethod("Write"),
                                    Expression.Constant("Inner lambda start")),
                            Expression.Call(null,
                                    typeof(ForSO).GetMethod("Write"),
                                    innerParam),
                            Expression.Call(null,
                                    typeof(ForSO).GetMethod("Write"),
                                    Param),
                            Expression.Call(null,
                                    typeof(ForSO).GetMethod("Write"),
                                    Expression.Constant("Inner lambda end"))
                        ),
                        innerParam
                    );
            }
    
            public static void Write(object toWrite) {
                Console.WriteLine(toWrite);
            }
    
            public static void Main(string[] args) {
                Console.WriteLine("-----------------------------------");
                ForSO so = new ForSO();
    
                LambdaWrapper wrapper = (LambdaWrapper) so.GetOuterLambda()
                                                        .Compile()
                                                        .DynamicInvoke();
                Console.WriteLine("-----------------------------------");
                wrapper.Execute("Calling from main");
            }
        }
    
    }
