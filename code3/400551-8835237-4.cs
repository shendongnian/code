    public class NullableValueProvider : IValueProvider
    {
        private readonly object _defaultValue;
        private readonly IValueProvider _underlyingValueProvider;
        public NullableValueProvider(MemberInfo memberInfo, Type underlyingType)
        {
            _underlyingValueProvider = new DynamicValueProvider(memberInfo);
            _defaultValue = Activator.CreateInstance(underlyingType);
        }
        public void SetValue(object target, object value)
        {
            _underlyingValueProvider.SetValue(target, value);
        }
        public object GetValue(object target)
        {
            return _underlyingValueProvider.GetValue(target) ?? _defaultValue;
        }
    }
    public class SpecialContractResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            if(member.MemberType == MemberTypes.Property)
            {
                var pi = (PropertyInfo) member;
                if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    return new NullableValueProvider(member, pi.PropertyType.GetGenericArguments().First());
                }
            }
            else if(member.MemberType == MemberTypes.Field)
            {
                var fi = (FieldInfo) member;
                if(fi.FieldType.IsGenericType && fi.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    return new NullableValueProvider(member, fi.FieldType.GetGenericArguments().First());
            }
            
            return base.CreateMemberValueProvider(member);
        }
    }
