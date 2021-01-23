    public class SomethingDependentOnCardRepository
    {
        // The parameter type should be IGenericRepository<Card> instead,
        // if you are using Unity to resolve this dependency.
        public SomethingDependentOnCardRepository(ICardRepository cardRepository)
        {
           // code
        }
    }
