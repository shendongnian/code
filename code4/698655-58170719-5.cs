    public class ConstructorParameterRelay<TTypeToConstruct, TValueType> : ISpecimenBuilder
    {
        private readonly string _paramName;
        private readonly TValueType _paramValue;
        public ConstructorParameterRelay(string paramName, TValueType paramValue)
        {
            _paramName = paramName;
            _paramValue = paramValue;
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            ParameterInfo parameter = request as ParameterInfo;
            if (parameter == null)
                return new NoSpecimen();
            if (parameter.Member.DeclaringType != typeof(TTypeToConstruct) ||
                parameter.Member.MemberType != MemberTypes.Constructor ||
                parameter.ParameterType != typeof(TValueType) ||
                parameter.Name != _paramName)
                return new NoSpecimen();
            return _paramValue;
        }
    }
