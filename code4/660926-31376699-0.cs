    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    namespace testProjectExpressions
    {
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst1 = new List<int>()
                             {
                                 1,
                                 2,
                                 3
                             };
            List<int> lst2 = new List<int>()
                             {
                                 4,
                                 5,
                                 6
                             };
            List<int> lst3 = new List<int>()
                             {
                                 7,
                                 8
                             };
            var fnc = CartesianProduct<int>(3);
            var res = fnc(new[] {lst1, lst2, lst3 });
            foreach (var product in res)
            {
                for (int index = 0; index < product.Length; index++)
                {
                    var productVar = product[index];
                    if (index < product.Length - 1)
                        Console.Write(productVar + ",");
                    else
                    {
                        Console.WriteLine(productVar);
                    }
                }
            }
            Console.ReadKey();
        }
        private static Func<List<T>[], List<T[]>> CartesianProduct<T>(int howMany)
        {
            var inputArrayOfLists = Expression.Parameter(typeof (List<T>[]), "inputArgument");
            ParameterExpression[] loopVariables = new ParameterExpression[howMany];
            for (int index = 0; index < howMany; index++)
                if (loopVariables[index] == null)
                    loopVariables[index] = Expression.Variable(typeof (T));
            List<Expression> finalStatements = new List<Expression>();
            // emit the create new object
            var resultExpression = Expression.Variable(typeof (List<T[]>), "result");
            var assignExpression = Expression.Assign(resultExpression, Expression.New(typeof (List<T[]>)));
            finalStatements.Add(assignExpression);
            // the "Add" method
            MethodInfo addMethod = typeof (List<T[]>).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            var EnumerableType = typeof(IEnumerable<T>);
            MethodInfo GetEnumeratorMethod = EnumerableType.GetMethod("GetEnumerator"); 
            var moveNextMethod = typeof(IEnumerator).GetMethod("MoveNext");
            Expression recursiveExpression = null;
            for (int index = 0; index < howMany; index++)
            {
                var variable = loopVariables[index];
                var indexAccess = Expression.ArrayIndex(inputArrayOfLists, Expression.Constant(index));
                var currentListExpression = indexAccess;
                if (recursiveExpression == null)
                {
                    var arrayVariable = Expression.Variable(typeof (T[]), "myArray");
                    List<Expression> initExpressions = new List<Expression>();
                    List<Expression> statements = new List<Expression>();
                    
                    var assign = Expression.Assign(arrayVariable, Expression.NewArrayInit(typeof (T), loopVariables));
                    statements.Add(assign);
                    Expression callAddExpression = Expression.Call(resultExpression, addMethod, arrayVariable);
                    statements.Add(callAddExpression);
                    recursiveExpression = Expression.Block(new[] {arrayVariable}, statements);
                }
                recursiveExpression = ForEachExpression(typeof(IEnumerator<T>), GetEnumeratorMethod, moveNextMethod,
                    currentListExpression, variable, recursiveExpression);
            }
            finalStatements.Add(recursiveExpression);
            finalStatements.Add(resultExpression);
            List<ParameterExpression> blockParameters = new List<ParameterExpression>(loopVariables);
            blockParameters.Add(resultExpression);
            Expression block = Expression.Block(blockParameters, finalStatements);
            var compiled = Expression.Lambda(block, inputArrayOfLists).Compile() as Func<List<T>[], List<T[]>>;
            return compiled;
        }
        // compiles a foreach expression on the given collection!
        public static Expression ForEachExpression(
                Type enumeratorType,
                MethodInfo getEnumeratorMethod,
                MethodInfo moveNextMethod,
                Expression collection,
                ParameterExpression loopVariable,
                Expression loopContent)
        {
            var breakLabel = Expression.Label("STOP");
            var enumeratorVar = Expression.Variable(enumeratorType, "collectionEnumerator");
            var loop = Expression.Block(new[] { enumeratorVar },
                Expression.Assign(enumeratorVar, Expression.Call(collection, getEnumeratorMethod)), // var enumerator = collection.GetEnumerator ();
                Expression.Loop(
                    Expression.IfThenElse(
                            Expression.Equal(Expression.Call(enumeratorVar, moveNextMethod), Expression.Constant(true)), // daca move_next e true
                            Expression.Block(new[] { loopVariable },
                                Expression.Assign(loopVariable, Expression.Property(enumeratorVar, "Current")), // loopVariable = enumeratorVar.Current
                                loopContent // do some stuff with that entity
                            ),
                        Expression.Break(breakLabel) // jmp to break
                    ),
                breakLabel) // break
            );
            return loop;
        }
    }
    }
