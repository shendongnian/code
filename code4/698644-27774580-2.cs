    public class ConstructorArgumentRelay<TTarget,TValueType> : ISpecimenBuilder
    {
        private readonly string _paramName;
        private readonly TValueType _value;
        public ConstructorArgumentRelay(string ParamName, TValueType value)
        {
            _paramName = ParamName;
            _value = value;
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            ParameterInfo parameter = request as ParameterInfo;
            if (parameter == null)
                return (object)new NoSpecimen(request);
            if (parameter.Member.DeclaringType != typeof(TTarget) ||
                parameter.Member.MemberType != MemberTypes.Constructor ||
                parameter.ParameterType != typeof(TValueType) ||
                parameter.Name != _paramName)
                return (object)new NoSpecimen(request);
            return _value;
        }
    }
