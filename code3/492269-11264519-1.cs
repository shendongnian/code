    public class SomeConcrete : ISomeInterface<ConcreteSearchCriteria>
    { 
        public TResultsType Results<TResultsType>(ConcreteSearchCriteria searchCriteria)
        {
             var results = GenerateResults();
             return (TResultsType)results;
        }
    }
