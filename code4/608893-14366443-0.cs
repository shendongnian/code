    public interface IC
    {
        string Prop1 { get; set; }
        string Prop2 { get; set; }
        string Prop3 { get; set; }
    }
    public class C1
    {
        [PropName("Prop1")]
        public string A { get; set; }
        [PropName("Prop2")]
        public string B { get; set; }
        [PropName("Prop3")]
        public string C { get; set; }
    }
    public class C2
    {
        [PropName("Prop1")]
        public string D { get; set; }
        [PropName("Prop2")]
        public string E { get; set; }
        [PropName("Prop3")]
        public string F { get; set; }
    }
    public class ProxyBuilder
    {
        private static readonly Dictionary<Tuple<Type, Type>, Type> _proxyClasses = new Dictionary<Tuple<Type, Type>, Type>();
        private static readonly AssemblyName _assemblyName = new AssemblyName("ProxyBuilderClasses");
        private static readonly AssemblyBuilder _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_assemblyName, AssemblyBuilderAccess.RunAndSave);
        private static readonly ModuleBuilder _moduleBuilder = _assemblyBuilder.DefineDynamicModule(_assemblyName.Name, _assemblyName.Name + ".dll");
        public static void SaveProxyAssembly()
        {
            _assemblyBuilder.Save(_assemblyName.Name + ".dll");
        }
        public static Type GetProxyTypeForBackingType(Type proxyInterface, Type backingType)
        {
            var key = Tuple.Create(proxyInterface, backingType);
            Type returnType;
            if (_proxyClasses.TryGetValue(key, out returnType))
                return returnType;
            var typeBuilder = _moduleBuilder.DefineType(
                "ProxyClassProxies." + "Proxy_" + proxyInterface.Name + "_To_" + backingType.Name,
                TypeAttributes.Public | TypeAttributes.Sealed,
                typeof (Object),
                new[]
                {
                    proxyInterface
                });
            //build backing object field
            var backingObjectField = typeBuilder.DefineField("_backingObject", backingType, FieldAttributes.Private);
            //build constructor
            var ctor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new[] {backingType});
            var ctorIL = ctor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            var ctorInfo = typeof (Object).GetConstructor(types: Type.EmptyTypes);
            ctorIL.Emit(OpCodes.Call, ctorInfo);
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Ldarg_1);
            ctorIL.Emit(OpCodes.Stfld, backingObjectField);
            ctorIL.Emit(OpCodes.Ret);
            foreach (var targetPropertyInfo in backingType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propertyName = targetPropertyInfo.Name;
                var attributes = targetPropertyInfo.GetCustomAttributes(typeof (PropName), true);
                if (attributes.Length > 0 && attributes[0] != null)
                    propertyName = (attributes[0] as PropName).Name;
                var propBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, targetPropertyInfo.PropertyType, null);
                const MethodAttributes getSetAttrs =
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Final | MethodAttributes.Virtual;
                //build get method
                var getBuilder = typeBuilder.DefineMethod(
                    "get_" + propertyName,
                    getSetAttrs,
                    targetPropertyInfo.PropertyType,
                    Type.EmptyTypes);
                var getIL = getBuilder.GetILGenerator();
                getIL.Emit(OpCodes.Ldarg_0);
                getIL.Emit(OpCodes.Ldfld, backingObjectField);
                getIL.EmitCall(OpCodes.Callvirt, targetPropertyInfo.GetGetMethod(), Type.EmptyTypes);
                getIL.Emit(OpCodes.Ret);
                propBuilder.SetGetMethod(getBuilder);
                //build set method
                var setBuilder = typeBuilder.DefineMethod(
                    "set_" + propertyName,
                    getSetAttrs,
                    null,
                    new[] {targetPropertyInfo.PropertyType});
                var setIL = setBuilder.GetILGenerator();
                setIL.Emit(OpCodes.Ldarg_0);
                setIL.Emit(OpCodes.Ldfld, backingObjectField);
                setIL.Emit(OpCodes.Ldarg_1);
                setIL.EmitCall(OpCodes.Callvirt, targetPropertyInfo.GetSetMethod(), new[] {targetPropertyInfo.PropertyType});
                setIL.Emit(OpCodes.Ret);
                propBuilder.SetSetMethod(setBuilder);
            }
            returnType = typeBuilder.CreateType();
            _proxyClasses.Add(key, returnType);
            return returnType;
        }
        public static TIProxy CreateProxyObject<TIProxy, TBackingObject>(TBackingObject backingObject, out TIProxy outProxy) where TIProxy : class
        {
            var t = GetProxyTypeForBackingType(typeof (TIProxy), typeof (TBackingObject));
            outProxy = Activator.CreateInstance(t, backingObject) as TIProxy;
            return outProxy;
        }
        private static void Main(string[] args)
        {
            var c1 = new C1();
            IC c1Proxy;
            CreateProxyObject(c1, out c1Proxy);
            var c2 = new C2();
            IC c2Proxy;
            CreateProxyObject(c2, out c2Proxy);
            c1Proxy.Prop1 = "c1Prop1Value";
            Debug.Assert(c1.A.Equals("c1Prop1Value"));
            c2Proxy.Prop1 = "c2Prop1Value";
            Debug.Assert(c2.D.Equals("c2Prop1Value"));
            //so you can check it out in reflector
            SaveProxyAssembly();
        }
        private static void OperationWithProp1(object o)
        {
            IC proxy;
            CreateProxyObject(o, out proxy);
            string prop1 = proxy.Prop1;
            // Do something with prop1
        }
