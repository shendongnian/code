    public class DelegateParameter : Parameter
    {
        private readonly string _name;
        private readonly Func<object> _getValue;
        public DelegateParameter(string name, Func<object> getValue)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (getValue == null) throw new ArgumentNullException("getValue");
            _name = name;
            _getValue = getValue;
        }
        public override bool CanSupplyValue(ParameterInfo pi, IComponentContext context, out Func<object> valueProvider)
        {
            PropertyInfo propertyInfo = GetProperty(pi);
            if (propertyInfo == null || propertyInfo.Name != _name)
            {
                valueProvider = null;
                return false;
            }
            valueProvider = _getValue;
            return true;
        }
        private static PropertyInfo GetProperty(ParameterInfo pi)
        {
            var methodInfo = pi.Member as MethodInfo;
            if (methodInfo != null && methodInfo.IsSpecialName && (methodInfo.Name.StartsWith("set_", StringComparison.Ordinal) && methodInfo.DeclaringType != null))
                return methodInfo.DeclaringType.GetProperty(methodInfo.Name.Substring(4));
            return null;
        }
    }
