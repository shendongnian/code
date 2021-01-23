    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    namespace emit
    {
    public class Proxy
    {
        #region static
        private static readonly AssemblyBuilder AssemblyBuilder;
        private static readonly ModuleBuilder ModuleBuilder;
        private static readonly object LockObj = new Object();
        private static readonly Dictionary<string, Type> TypeCache = new Dictionary<string, Type>();
        static Proxy()
        {
            lock (LockObj)
            {
                AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    new AssemblyName("Taga.Proxies"),
                    AssemblyBuilderAccess.Run);
                var assemblyName = AssemblyBuilder.GetName().Name;
                ModuleBuilder = AssemblyBuilder.DefineDynamicModule(assemblyName);
            }
        }
        private static Type GetImplementedType(Type baseType, Type[] interfaceTypes)
        {
            var key = GetTypeKey(baseType, interfaceTypes);
            return TypeCache.ContainsKey(key) ? TypeCache[key] : null;
        }
        private static void AddImplementation(Type baseType, Type[] interfaceTypes, Type implementationType)
        {
            var key = GetTypeKey(baseType, interfaceTypes);
            TypeCache.Add(key, implementationType);
        }
        private static string GetTypeKey(Type baseType, Type[] interfaceTypes)
        {
            var key = String.Empty;
            key += baseType.FullName;
            key = interfaceTypes.Aggregate(key, (current, interfaceType) => current + interfaceType);
            return key;
        }
        public static TBase Of<TBase>(ICallHandler callHandler, params Type[] interfaceTypes) where TBase : class
        {
            var builder = new Proxy(typeof(TBase), interfaceTypes);
            var type = builder.GetProxyType();
            return (TBase)Activator.CreateInstance(type, callHandler);
        }
        public static object Of(ICallHandler callHandler, Type[] interfaceTypes)
        {
            if (interfaceTypes == null || interfaceTypes.Length == 0)
                throw new InvalidOperationException("No interface type specified");
            return Of<object>(callHandler, interfaceTypes);
        }
        #endregion
        #region Proxy
        private TypeBuilder _typeBuilder;
        private FieldBuilder _callHandlerFieldBuilder;
        private readonly Type _baseClassType;
        private readonly Type[] _interfaceTypes;
        private Proxy(Type baseClassType, Type[] interfaceTypes)
        {
            if (interfaceTypes == null || !interfaceTypes.Any())
                _interfaceTypes = Type.EmptyTypes;
            else if (interfaceTypes.Any(it => !it.IsInterface || !it.IsPublic || it.IsGenericType))
                throw new InvalidOperationException("Interface Types must be public and non generic");
            else
                _interfaceTypes = interfaceTypes;
            if (baseClassType == null)
                _baseClassType = typeof(object);
            else if (!baseClassType.IsClass || baseClassType.IsAbstract || baseClassType.IsGenericType || baseClassType.IsSealed || !baseClassType.IsPublic || !baseClassType.HasDefaultConstructor())
                throw new InvalidOperationException("Base Class Type must be a public, non-sealed, non-abstract, non-generic class with a public default constructor");
            else
                _baseClassType = baseClassType;
        }
        private string _typeName;
        private string TypeName
        {
            get { return _typeName ?? (_typeName = BuildTypeName()); }
        }
        private string BuildTypeName()
        {
            var typeName = "__";
            if (_baseClassType != null)
                typeName += _baseClassType.Name + "__";
            foreach (var interfaceType in _interfaceTypes)
                typeName += interfaceType.Name + "__";
            return typeName + "Proxy__";
        }
        private Type GetProxyType()
        {
            var type = GetImplementedType(_baseClassType, _interfaceTypes);
            if (type != null)
                return type;
            type = BuildType();
            
            AddImplementation(_baseClassType, _interfaceTypes, type);
            return type;
        }
        private Type BuildType()
        {
            InitTypeBuilder();
            DefineCallHandlerField();
            BuildConstructor();
            ExtendBase();
            ImplementInterfaces();
            return _typeBuilder.CreateType();
        }
        private void InitTypeBuilder()
        {
            // public class __BaseClass__Interface1__Interface2__Proxy__ : BaseClass, Interface1, Interface2
            _typeBuilder = ModuleBuilder.DefineType(
                TypeName,
                TypeAttributes.Public | TypeAttributes.Class,
                _baseClassType,
                _interfaceTypes);
        }
        private void DefineCallHandlerField()
        {
            // private ICallHandler _callHandler;
            _callHandlerFieldBuilder = _typeBuilder.DefineField("_callHandler", typeof(ICallHandler), FieldAttributes.Private);
        }
        private void BuildConstructor()
        {
            var constructorBuilder = DeclareContsructor();   // public ProxyClass(ICallHandler callHandler)
            ImplementConstructor(constructorBuilder);       // : base() { this._callHandler = callHandler; }
        }
        private void ExtendBase()
        {
            foreach (var mi in _baseClassType.GetVirtualMethods())
                BuildMethod(mi);
        }
        private void ImplementInterfaces()
        {
            foreach (var methodInfo in _interfaceTypes.SelectMany(interfaceType => interfaceType.GetMethods()))
                BuildMethod(methodInfo);
        }
        private ConstructorBuilder DeclareContsructor()
        {
            var constructorBuilder = _typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.HasThis,
                new[] { typeof(ICallHandler) });
            return constructorBuilder;
        }
        private void ImplementConstructor(ConstructorBuilder constructorBuilder)
        {
            var baseCtor = _baseClassType.GetConstructor(Type.EmptyTypes);
            var il = constructorBuilder.GetILGenerator();
            // call base ctor
            il.Emit(OpCodes.Ldarg_0); // push this
            il.Emit(OpCodes.Call, baseCtor); // Call base constructor this.base(); pops this
            // set _callHandler
            il.Emit(OpCodes.Ldarg_0); // push this
            il.Emit(OpCodes.Ldarg_1); // push callHandler argument
            il.Emit(OpCodes.Stfld, _callHandlerFieldBuilder); // this._callHandler = callHandler, pop this, pop callhandler argument
            
            il.Emit(OpCodes.Ret); // exit ctor
        }
        private void BuildMethod(MethodInfo mi)
        {
            var methodBuilder = CallHandlerMethodBuilder.GetInstance(_typeBuilder, mi, _callHandlerFieldBuilder);
            methodBuilder.Build();
        }
        #endregion
    }
    class CallHandlerMethodImplementor : CallHandlerMethodBuilder
    {
        internal CallHandlerMethodImplementor(TypeBuilder typeBuilder, MethodInfo methodInfo, FieldBuilder callHandlerFieldBuilder)
            : base(typeBuilder, methodInfo, callHandlerFieldBuilder)
        {
        }
        protected override void SetReturnValue()
        {
            // object res = returnValue;
            ReturnValue = IL.DeclareLocal(typeof(object));
            if (MethodInfo.ReturnType != typeof(void))
                IL.Emit(OpCodes.Stloc, ReturnValue); // pop return value of BeforeCall into res
            else
                IL.Emit(OpCodes.Pop); // pop return value of BeforeCall
        }
    }
    class CallHandlerMethodOverrider : CallHandlerMethodBuilder
    {
        internal CallHandlerMethodOverrider(TypeBuilder typeBuilder, MethodInfo methodInfo, FieldBuilder callHandlerFieldBuilder)
            : base(typeBuilder, methodInfo, callHandlerFieldBuilder)
        {
        }
        protected override void SetReturnValue()
        {
            // ReturnValue = base.Method(args...)
            CallBaseMethod();
            // stack'ta base'den dönen değer var
            SetReturnValueFromBase();
        }
        private void CallBaseMethod()
        {
            IL.Emit(OpCodes.Pop); // pop return value of BeforeCall
            // base'den Method'u çağır
            // returnValue = base.Method(params...)
            IL.Emit(OpCodes.Ldarg_0); // push this 
            for (var i = 0; i < ParameterCount; i++)  // metoda gelen parametreleri stack'e at
                IL.Emit(OpCodes.Ldarg_S, i + 1);// push params[i]
            IL.Emit(OpCodes.Call, MethodInfo); // base.Method(params) pop this, pop params push return value
        }
        private void SetReturnValueFromBase()
        {
            ReturnValue = IL.DeclareLocal(typeof(object));
            if (MethodInfo.ReturnType == typeof(void))
                return;
            // unbox returnValue if required
            if (MethodInfo.ReturnType.IsValueType)
                IL.Emit(OpCodes.Box, MethodInfo.ReturnType);
            IL.Emit(OpCodes.Stloc, ReturnValue); // pop return value into res
        }
    }
    abstract class CallHandlerMethodBuilder
    {
        private ParameterInfo[] _parameters;
        private MethodBuilder _methodBuilder;
        private readonly TypeBuilder _typeBuilder;
        private readonly FieldBuilder _callHandlerFieldBuilder;
        protected readonly MethodInfo MethodInfo;
        protected ILGenerator IL { get; private set; }
        protected int ParameterCount { get; private set; }
        private MethodInfo _beforeCall;
        private MethodInfo BeforeCall
        {
            get
            {
                return _beforeCall ?? (_beforeCall = typeof(ICallHandler).GetMethods().First(m => m.Name == "BeforeMethodCall"));
            }
        }
        private MethodInfo _afterCall;
        private MethodInfo AfterCall
        {
            get
            {
                return _afterCall ?? (_afterCall = typeof(ICallHandler).GetMethods().First(m => m.Name == "AfterMethodCall"));
            }
        }
        private MethodInfo _onError;
        private MethodInfo OnError
        {
            get
            {
                return _onError ?? (_onError = typeof(ICallHandler).GetMethods().First(m => m.Name == "OnError"));
            }
        }
        protected CallHandlerMethodBuilder(TypeBuilder typeBuilder, MethodInfo methodInfo, FieldBuilder callHandlerFieldBuilder)
        {
            _typeBuilder = typeBuilder;
            MethodInfo = methodInfo;
            _callHandlerFieldBuilder = callHandlerFieldBuilder;
        }
        private void Declare()
        {
            // public override? ReturnType Method(arguments...)
            _methodBuilder = _typeBuilder.DefineMethod(MethodInfo.Name,
                                                          MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                                                          MethodInfo.ReturnType,
                                                          MethodInfo.GetParameterTypes());
            IL = _methodBuilder.GetILGenerator();
            _parameters = MethodInfo.GetParameters();
            ParameterCount = _parameters.Length;
        }
        private LocalBuilder _objParameter;
        private void SetObjectParameter()
        {
            // CallHandlera verilecek object obj
            _objParameter = IL.DeclareLocal(typeof(object)); // object obj;
            IL.Emit(OpCodes.Ldarg_0); // push this
            IL.Emit(OpCodes.Stloc, _objParameter); // obj = this; pops this
        }
        private LocalBuilder _methodInfoParameter;
        private void SetMethodInfoParameter()
        {
            // CallHandlera verilecek MethodInfo methodInfo
            _methodInfoParameter = IL.DeclareLocal(typeof(MethodInfo)); // MethodInfo methodInfo;
            IL.Emit(OpCodes.Ldtoken, MethodInfo);
            IL.Emit(OpCodes.Call, typeof(MethodBase).GetMethod(
                "GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle) })); // MethodBase.GetMethodFromHandle(new RuntimeMethodHandle());
            IL.Emit(OpCodes.Stloc, _methodInfoParameter);
        }
        private LocalBuilder _argsParameter;
        private void SetArgsParameters()
        {
            // CallHandlera verilecek object[] args
            _argsParameter = IL.DeclareLocal(typeof(object[])); // object[] args;
            IL.Emit(OpCodes.Ldc_I4, ParameterCount); // push parameterCount as Int32
            IL.Emit(OpCodes.Newarr, typeof(object)); // push new object[parameterCount]; pops parameterCount
            IL.Emit(OpCodes.Stloc, _argsParameter); // args = new object[ParameterCount]; pops new object[parameterCount]
            // Metoda gelen parametreleri args'a doldur
            for (var i = 0; i < ParameterCount; i++)
            {
                var parameterInfo = _parameters[i];
                IL.Emit(OpCodes.Ldloc, _argsParameter); // push args
                IL.Emit(OpCodes.Ldc_I4, i); // push i
                IL.Emit(OpCodes.Ldarg_S, i + 1); // push params[i]; pops i; metoda gelen parametrelerin i'incisi. 0'ıncı parametre this olduğu için  "+1" var
                if (parameterInfo.ParameterType.IsPrimitive || parameterInfo.ParameterType.IsValueType)
                    IL.Emit(OpCodes.Box, parameterInfo.ParameterType); // (object)params[i]
                IL.Emit(OpCodes.Stelem_Ref); // args[i] = (object)params[i]; pops params[i]
            }
        }
        private void Try()
        {
            IL.BeginExceptionBlock(); // try {
        }
        private void InvokeBeforeMethodCall()
        {
            // this._callHandler.BeforeCall(obj, methodInfo, args);
            IL.Emit(OpCodes.Ldarg_0); // push this
            IL.Emit(OpCodes.Ldfld, _callHandlerFieldBuilder); // push _callHandler; pops this
            IL.Emit(OpCodes.Ldloc, _objParameter); // push obj
            IL.Emit(OpCodes.Ldloc, _methodInfoParameter); // push methodInfo 
            IL.Emit(OpCodes.Ldloc, _argsParameter); // push args
            IL.Emit(OpCodes.Call, BeforeCall); // _callHandler.BeforeCall(obj, methodInfo, args); push return value
        }
        protected LocalBuilder ReturnValue;
        protected abstract void SetReturnValue();
        private void InvokeAfterMethodCall()
        {
            // this._callHandler.AfterCall(obj, methodInfo, args, returnValue);
            IL.Emit(OpCodes.Ldarg_0); // push this
            IL.Emit(OpCodes.Ldfld, _callHandlerFieldBuilder); // push _callHandler; pops this
            IL.Emit(OpCodes.Ldloc, _objParameter); // push obj
            IL.Emit(OpCodes.Ldloc, _methodInfoParameter); // push methodInfo 
            IL.Emit(OpCodes.Ldloc, _argsParameter); // push args
            IL.Emit(OpCodes.Ldloc, ReturnValue); // push res
            IL.Emit(OpCodes.Call, AfterCall); // _callHandler.AfterCall(obj, methodInfo, args, returnValue); push return value (void değilse)
        }
        private void Catch()
        {
            var ex = IL.DeclareLocal(typeof(Exception)); 
            
            IL.BeginCatchBlock(typeof(Exception));          // catch 
            IL.Emit(OpCodes.Stloc_S, ex);                   // (Exception ex) {
            InvokeOnError(ex);                              //     _callHandler.AfterCall(obj, methodInfo, args);
            IL.EndExceptionBlock();                         // }
        }
        private void InvokeOnError(LocalBuilder exception)
        {
            // this._callHandler.OnError(obj, methodInfo, args);
            IL.Emit(OpCodes.Ldarg_0); // push this
            IL.Emit(OpCodes.Ldfld, _callHandlerFieldBuilder); // push _callHandler; pops this
            IL.Emit(OpCodes.Ldloc, _objParameter); // push obj
            IL.Emit(OpCodes.Ldloc, _methodInfoParameter); // push methodInfo 
            IL.Emit(OpCodes.Ldloc, _argsParameter); // push args
            IL.Emit(OpCodes.Ldloc, exception); // push ex
            IL.Emit(OpCodes.Call, OnError); // _callHandler.AfterCall(obj, methodInfo, args);
        }
        private void Return()
        {
            if (MethodInfo.ReturnType != typeof(void))
            {
                IL.Emit(OpCodes.Ldloc, ReturnValue); // push returnValue
                IL.Emit(OpCodes.Unbox_Any, MethodInfo.ReturnType); // (ReturnType)returnValue
            }
            IL.Emit(OpCodes.Ret); // returns the value on the stack, if ReturnType is void stack should be empty
        }
        internal void Build()
        {
            Declare();                   // public override? ReturnType Method(arguments...) {
            SetObjectParameter();        //     object obj = this;
            SetMethodInfoParameter();    //     MethodInfo methodInfo = MethodBase.GetMethodFromHandle(new RuntimeMethodHandle());
            SetArgsParameters();         //     object[] args = arguments;
            Try();                       //     try {
            InvokeBeforeMethodCall();    //         object returnValue = _callHandler.BeforeMethodCall(obj, methodInfo, args);
            SetReturnValue();            //         !IsAbstract => returnValue = (object)base.Method(arguments);
            InvokeAfterMethodCall();     //         _callHandler.AfterMethodCall(obj, methodInfo, args, returnValue);
            Catch();                     //      } catch (Exception ex) { _callHandler.OnError(obj, methodInfo, args, ex); }
            Return();                    //     IsVoid ? (return;) : return (ReturnType)returnValue; }
        }
        internal static CallHandlerMethodBuilder GetInstance(TypeBuilder typeBuilder, MethodInfo methodInfo, FieldBuilder callHandlerFieldBuilder)
        {
            if (methodInfo.IsAbstract)
                return new CallHandlerMethodImplementor(typeBuilder, methodInfo, callHandlerFieldBuilder);
            return new CallHandlerMethodOverrider(typeBuilder, methodInfo, callHandlerFieldBuilder);
        }
    }
    public interface ICallHandler
    {
        object  BeforeMethodCall    (object obj, MethodInfo mi, object[] args);
        void    AfterMethodCall     (object obj, MethodInfo mi, object[] args, object returnValue);
        void    OnError             (object obj, MethodInfo mi, object[] args, Exception exception);
    }
    static class ReflectionExtensions
    {
        public static bool HasDefaultConstructor(this Type type)
        {
            return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Any(ctor => !ctor.GetParameters().Any());
        }
        public static Type[] GetParameterTypes(this MethodInfo methodInfo)
        {
            return methodInfo.GetParameters().Select(pi => pi.ParameterType).ToArray();
        }
        public static MethodBuilder GetMethodBuilder(this TypeBuilder typeBuilder, MethodInfo mi)
        {
            // MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual
            return typeBuilder.DefineMethod(mi.Name, mi.Attributes, mi.ReturnType, mi.GetParameterTypes());
        }
        public static MethodInfo[] GetVirtualMethods(this Type type)
        {
            return type.GetMethods().Where(mi => mi.IsVirtual).ToArray();
        }
        public static object GetDefaultValue(this Type t)
        {
            return typeof(ReflectionExtensions).GetMethod("Default").MakeGenericMethod(t).Invoke(null, null);
        }
        public static T Default<T>()
        {
            return default(T);
        }
    }
    }
