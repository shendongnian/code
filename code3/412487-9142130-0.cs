    public class SomethingDependentOnCardRepository
    {
        // The parameter type should be IGenericRepository<Card> instead
        public SomethingDependentOnCardRepository(ICardRepository cardRepository)
        {
           // code
        }
    }
