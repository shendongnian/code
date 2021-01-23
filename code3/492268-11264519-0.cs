    public class SomeConcrete : ISomeInterface<ConcreteSearchCriteria>
    { 
        public TResultsType Results<TResultsType, ConcreteSearchCriteria>(ConcreteSearchCriteria searchCriteria)
        {
             var results = GenerateResults();
             return (TResultsType)results;
        }
    }
