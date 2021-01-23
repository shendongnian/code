    class DynamicNode : DynamicObject, IExpando, IEnumerable
    {
        private IExpando value;
        public DynamicNode(IExpando value)
        {
            this.value = value;
        }
        public override bool TryUnaryOperation(UnaryOperationBinder binder, out object result)
        {
            switch (binder.Operation)
            {
                case System.Linq.Expressions.ExpressionType.Convert:
                case System.Linq.Expressions.ExpressionType.ConvertChecked:
                    result = this.value;
                    return true;
            }
            return base.TryUnaryOperation(binder, out result);
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.value
                .GetMembers(BindingFlags.Instance | BindingFlags.Public)
                .Select(m => m.Name)
                .Distinct()
                .ToArray();
        }
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            result = this.value;
            return true;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1)
            {
                var memberName = indexes[0].ToString();
                result = ReflectionHelpers.GetValue(this.value, memberName);
                result = DynamicNode.Wrap(result);
                return true;
            }
            return base.TryGetIndex(binder, indexes, out result);
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length == 1)
            {
                var memberName = indexes[0].ToString();
                value = DynamicNode.Unwrap(value);
                ReflectionHelpers.SetValue(this.value, memberName, value);
                return true;
            }
            return base.TrySetIndex(binder, indexes, value);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (base.TryGetMember(binder, out result))
                return true;
            result = ReflectionHelpers.GetValue(this.value, binder.Name);
            result = DynamicNode.Wrap(result);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            ReflectionHelpers.SetValue(this.value, binder.Name, value);
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name == "New")
            {
                var constructorArgs = new object[args.Length - 1];
                Array.ConstrainedCopy(args, 1, constructorArgs, 0, constructorArgs.Length);
                result = ReflectionHelpers.New(this.value, (string)args[0], constructorArgs);
            }
            else
            {
                result = ReflectionHelpers.Invoke(this.value, binder.Name, args);
            }
            result = DynamicNode.Wrap(result);
            return true;
        }
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            IExpando self = this.value;
            object[] constructorArgs = new object[0];
            if (args.Length > 0)
            {
                self = (IExpando)DynamicNode.Unwrap(args[0]);
                constructorArgs = new object[args.Length - 1];
                Array.ConstrainedCopy(args, 1, constructorArgs, 0, constructorArgs.Length);
            }
            result = ReflectionHelpers.Call(this.value, self, constructorArgs);
            result = DynamicNode.Wrap(result);
            return true;
        }
        private static object Wrap(object value)
        {
            if (value != null && Marshal.IsComObject(value))
                value = new DynamicNode((IExpando)value);
            return value;
        }
        public static object Unwrap(object value)
        {
            DynamicNode node = value as DynamicNode;
            if (node != null)
                return node.value;
            return value;
        }
        public IEnumerator GetEnumerator()
        {
            var members = this.value.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var indexProperties = new List<Tuple<int, PropertyInfo>>();
            var isArray = true;
            foreach (var member in members)
            {
                int value = 0;
                if (!int.TryParse(member.Name, out value))
                {
                    isArray = false;
                    break;
                }
                var propertyMember = member as PropertyInfo;
                if (propertyMember != null)
                    indexProperties.Add(Tuple.Create(value, propertyMember));
            }
            if (isArray)
            {
                indexProperties.Sort((left, right) => left.Item1.CompareTo(right.Item1));
                foreach (var prop in indexProperties)
                    yield return prop.Item2.GetValue(this.value, null);
            }
            else
            {
                foreach (var member in members)
                    yield return member.Name;
            }
        }
        #region IExpando
        FieldInfo IExpando.AddField(string name)
        {
            return this.value.AddField(name);
        }
        MethodInfo IExpando.AddMethod(string name, Delegate method)
        {
            return this.value.AddMethod(name, method);
        }
        PropertyInfo IExpando.AddProperty(string name)
        {
            return this.value.AddProperty(name);
        }
        void IExpando.RemoveMember(MemberInfo m)
        {
            this.value.RemoveMember(m);
        }
        FieldInfo IReflect.GetField(string name, BindingFlags bindingAttr)
        {
            return this.value.GetField(name, bindingAttr);
        }
        FieldInfo[] IReflect.GetFields(BindingFlags bindingAttr)
        {
            return this.value.GetFields(bindingAttr);
        }
        MemberInfo[] IReflect.GetMember(string name, BindingFlags bindingAttr)
        {
            return this.value.GetMember(name, bindingAttr);
        }
        MemberInfo[] IReflect.GetMembers(BindingFlags bindingAttr)
        {
            return this.value.GetMembers(bindingAttr);
        }
        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr)
        {
            return this.value.GetMethod(name, bindingAttr);
        }
        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return this.value.GetMethod(name, bindingAttr, binder, types, modifiers);
        }
        MethodInfo[] IReflect.GetMethods(BindingFlags bindingAttr)
        {
            return this.value.GetMethods(bindingAttr);
        }
        PropertyInfo[] IReflect.GetProperties(BindingFlags bindingAttr)
        {
            return this.value.GetProperties(bindingAttr);
        }
        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return this.value.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
        }
        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr)
        {
            return this.value.GetProperty(name, bindingAttr);
        }
        object IReflect.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            return this.value.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
        }
        Type IReflect.UnderlyingSystemType
        {
            get { return this.value.UnderlyingSystemType; }
        }
        #endregion
    }
    [ComVisible(true)]
    public class ScriptObject : IReflect, IExpando
    {
        private readonly Type type;
        private dynamic _constructor;
        private dynamic _prototype;
        public ScriptObject()
        {
            type = this.GetType();
        }
        [DispId(0)]
        protected virtual object Invoke(object[] args)
        {
            return "ClrObject";
        }
        public dynamic constructor
        {
            get { return _constructor; }
            set { this._constructor = value; }
        }
        public dynamic prototype
        {
            get { return _prototype; }
            set { this._prototype = value; }
        }
        public string toString()
        {
            return "ClrObject";
        }
        #region IReflect Members
        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder, types, modifiers);
        }
        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr);
        }
        protected virtual MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            return type.GetMethods(bindingAttr);
        }
        MethodInfo[] IReflect.GetMethods(BindingFlags bindingAttr)
        {
            return GetMethods(bindingAttr);
        }
        FieldInfo IReflect.GetField(string name, BindingFlags bindingAttr)
        {
            return type.GetField(name, bindingAttr);
        }
        FieldInfo[] IReflect.GetFields(BindingFlags bindingAttr)
        {
            return new FieldInfo[0]; // type.GetFields(bindingAttr);
        }
        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr);
        }
        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
        }
        protected virtual PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            return type.GetProperties(bindingAttr);
        }
        PropertyInfo[] IReflect.GetProperties(BindingFlags bindingAttr)
        {
            return GetProperties(bindingAttr);
        }
        MemberInfo[] IReflect.GetMember(string name, BindingFlags bindingAttr)
        {
            return type.GetMember(name, bindingAttr);
        }
        MemberInfo[] IReflect.GetMembers(BindingFlags bindingAttr)
        {
            return type.GetMembers(bindingAttr);
        }
        protected virtual object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
        {
            if (name == "[DISPID=0]")
            {
                return this.Invoke(args);
            }
            return type.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
        }
        object IReflect.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
        {
            return this.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
        }
        Type IReflect.UnderlyingSystemType
        {
            get { return type.UnderlyingSystemType; }
        }
        #endregion
        #region IExpando Members
        public FieldInfo AddField(string name)
        {
            throw new NotImplementedException();
        }
        public MethodInfo AddMethod(string name, Delegate method)
        {
            throw new NotImplementedException();
        }
        public PropertyInfo AddProperty(string name)
        {
            throw new NotImplementedException();
        }
        public void RemoveMember(MemberInfo m)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public static class ReflectionHelpers
    {
        private const BindingFlags DefaultFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        public static object New(this IExpando scope, string functionName, params object[] args)
        {
            var constructor = (IExpando)scope.GetValue(functionName);
            var proto = constructor.GetValue("prototype");
            var obj = (IExpando)scope.GetValue("Object");
            var instance = (IExpando)obj.Invoke("create", new object[] { proto });
            Call(constructor, instance, args);
            return instance;
        }
        public static object Call(this IExpando function, IExpando scope, params object[] args)
        {
            object[] callArgs = new object[args.Length + 1];
            callArgs[0] = scope;
            Array.Copy(args, 0, callArgs, 1, args.Length);
            return Invoke(function, "call", callArgs);
        }
        public static void SetValue(this IExpando instance, string propertyName, object value)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Must specify a value.", "propertyName");
            Invoke(instance, propertyName, InvokeFlags.DISPATCH_PROPERTYPUT, new object[] { value });
        }
        public static object GetValue(this IExpando instance, string propertyName)
        {
            return Invoke(instance, propertyName, InvokeFlags.DISPATCH_PROPERTYGET, new object[0]);
        }
        public static object Invoke(this IExpando instance, string functionName, object[] args)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (string.IsNullOrEmpty(functionName))
                throw new ArgumentException("Must specify a value.", "functionName");
            return Invoke(instance, functionName, InvokeFlags.DISPATCH_METHOD, args);
        }
        private static object Invoke(IExpando instance, string functionName, InvokeFlags flags, object[] args)
        {
            try
            {
                args = args.Select(arg => DynamicNode.Unwrap(arg)).ToArray();
                switch (flags)
                {
                    case InvokeFlags.DISPATCH_METHOD:
                        var method = instance.GetMethod(functionName, DefaultFlags);
                        return method.Invoke(instance, args);
                    case InvokeFlags.DISPATCH_PROPERTYGET:
                        var getProp = instance.GetProperty(functionName, DefaultFlags);
                        return getProp.GetValue(instance, null);
                    case InvokeFlags.DISPATCH_PROPERTYPUT:
                    case InvokeFlags.DISPATCH_PROPERTYPUTREF:
                        var setProp = instance.GetProperty(functionName, DefaultFlags);
                        if (setProp == null)
                            setProp = instance.AddProperty(functionName);
                        setProp.SetValue(instance, args[0], null);
                        return null;
                    default:
                        throw new NotSupportedException();
                }
            }
            catch (COMException comex)
            {
                switch ((uint)comex.ErrorCode)
                {
                    // Unexpected script error. This will be handled by the IProcess.UnhandledException event
                    case 0x80020101:
                        return null;
                    default:
                        throw;
                }
            }
        }
        private enum InvokeFlags
        {
            DISPATCH_METHOD = 1,
            DISPATCH_PROPERTYGET = 2,
            DISPATCH_PROPERTYPUT = 4,
            DISPATCH_PROPERTYPUTREF = 8,
        }
    }
