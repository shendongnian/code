    public class SomeConcrete : ISomeInterface
    {
        TResultsType ISomeInterface.Results<TResultsType, TSearchCriteriaType>(TSearchCriteriaType searchCriteria)
        {
            return Results<TResultsType>((ConcreteSearchCriteria)(object)searchCriteria);
        }
        public TResultsType Results<TResultsType>(ConcreteSearchCriteria searchCriteria)
        {
            // return something
        }
    }
