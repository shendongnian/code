    public interface ISomeInterface<out TResultsType, in TSearchCriteriaType> {
      TResultsType Results(TSearchCriteriaType searchCriteria);
    }
    public class SomeConcrete<TResultsType> : 
      ISomeInterface<TResultsType, ConcreteSearchCriteria> {
      public TResultsType Results(ConcreteSearchCriteria searchCriteria) {
        ...
      }
    }
