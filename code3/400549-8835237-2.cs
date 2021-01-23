    public class SpecialContractResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            var pi = member as PropertyInfo;
            if (pi != null && pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return new NullableValueProvider(pi, pi.PropertyType.GetGenericArguments().First());
            }
            return base.CreateMemberValueProvider(member);
        }
    }
    public class NullableValueProvider : IValueProvider
    {
        private readonly PropertyInfo _pi;
        private object _defaultValue;
        public NullableValueProvider(PropertyInfo pi, Type underlyingType)
        {
            _pi = pi;
            _defaultValue = Activator.CreateInstance(underlyingType);
        }
        public void SetValue(object target, object value)
        {
            throw new NotImplementedException();
        }
        public object GetValue(object target)
        {
            return _pi.GetValue(target, null) ?? _defaultValue;
        }
    }
