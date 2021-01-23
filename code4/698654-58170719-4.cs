    public class SetCreateProvider<TTypeToConstruct>
    {
        private readonly IFixture _fixture;
        public SetCreateProvider(IFixture fixture)
        {
            _fixture = fixture;
        }
        public SetProvider<TTypeToConstruct> Set(string parameterName)
        {
            return new SetProvider<TTypeToConstruct>(this, parameterName);
        }
        public TTypeToConstruct Create()
        {
            var instance = _fixture.Create<TTypeToConstruct>();
            return instance;
        }
        internal void AddConstructorParameter<TTypeOfParam>(ConstructorParameterRelay<TTypeToConstruct, TTypeOfParam> constructorParameter)
        {
            _fixture.Customizations.Add(constructorParameter);
        }
    }
    public class SetProvider<TTypeToConstruct>
    {
        private readonly string _parameterName;
        private readonly SetCreateProvider<TTypeToConstruct> _father;
        public SetProvider(SetCreateProvider<TTypeToConstruct> father, string parameterName)
        {
            _parameterName = parameterName;
            _father = father;
        }
        public SetCreateProvider<TTypeToConstruct> To<TTypeOfParam>(TTypeOfParam parameterValue)
        {
            var constructorParameter = new ConstructorParameterRelay<TTypeToConstruct, TTypeOfParam>(_parameterName, parameterValue);
            _father.AddConstructorParameter(constructorParameter);
            return _father;
        }
        public SetCreateProvider<TTypeToConstruct> ToEnumerableOf<TTypeOfParam>(params TTypeOfParam[] parametersValues)
        {
            IEnumerable<TTypeOfParam> actualParamValue = parametersValues;
            var constructorParameter = new ConstructorParameterRelay<TTypeToConstruct, IEnumerable<TTypeOfParam>>(_parameterName, actualParamValue);
            _father.AddConstructorParameter(constructorParameter);
            return _father;
        }
    }
