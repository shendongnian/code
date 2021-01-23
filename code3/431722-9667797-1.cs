    public class MyType : Type
    {
        private Type internalType;
        public MyType(Type t)
        {
            internalType = t;
        }
        public static Boolean operator >(MyType t1, Type t2)
        {
            //TODO once it compiles
            return false;
        }
        public static Boolean operator <(MyType t1, Type t2)
        {
            //TODO once it compiles
            return true;
        }
        public override Assembly Assembly
        {
            get { return internalType.Assembly; }
        }
        public override string AssemblyQualifiedName
        {
            get { return internalType.AssemblyQualifiedName; }
        }
        public override Type BaseType
        {
            get { return internalType.BaseType; }
        }
        public override string FullName
        {
            get { return internalType.FullName; }
        }
        public override Guid GUID
        {
            get { return internalType.GUID; }
        }
        protected override TypeAttributes GetAttributeFlagsImpl()
        {
            return internalType.Attributes;
        }
        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return internalType.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
        }
        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            return internalType.GetConstructors(bindingAttr);
        }
        public override Type GetElementType()
        {
            return GetElementType();
        }
        public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
        {
            return internalType.GetEvent(name, bindingAttr);
        }
        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        {
            return internalType.GetEvents(bindingAttr);
        }
        public override FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            return internalType.GetField(name, bindingAttr);
        }
        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            return internalType.GetFields(bindingAttr);
        }
        public override Type GetInterface(string name, bool ignoreCase)
        {
            return internalType.GetInterface(name, ignoreCase);
        }
        public override Type[] GetInterfaces()
        {
            return internalType.GetInterfaces();
        }
        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            return internalType.GetMembers(bindingAttr);
        }
        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return internalType.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
        }
        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            return internalType.GetMethods(bindingAttr);
        }
        public override Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            return internalType.GetNestedType(name, bindingAttr);
        }
        public override Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            return internalType.GetNestedTypes(bindingAttr);
        }
        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            return internalType.GetProperties(bindingAttr);
        }
        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return internalType.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
        }
        protected override bool HasElementTypeImpl()
        {
            return internalType.HasElementType;
        }
        public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            return internalType.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
        }
        protected override bool IsArrayImpl()
        {
            return internalType.IsArray;
        }
        protected override bool IsByRefImpl()
        {
            return internalType.IsByRef;
        }
        protected override bool IsCOMObjectImpl()
        {
            return internalType.IsCOMObject;
        }
        protected override bool IsPointerImpl()
        {
            return internalType.IsPointer;
        }
        protected override bool IsPrimitiveImpl()
        {
            return internalType.IsPrimitive;
        }
        public override Module Module
        {
            get { return internalType.Module; }
        }
        public override string Namespace
        {
            get { return internalType.Namespace; }
        }
        public override Type UnderlyingSystemType
        {
            get { return internalType.UnderlyingSystemType; }
        }
        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return internalType.GetCustomAttributes(attributeType, inherit);
        }
        public override object[] GetCustomAttributes(bool inherit)
        {
            return internalType.GetCustomAttributes(inherit);
        }
        public override bool IsDefined(Type attributeType, bool inherit)
        {
            return internalType.IsDefined(attributeType, inherit);
        }
        public override string Name
        {
            get { return internalType.Name; }
        }
    }
