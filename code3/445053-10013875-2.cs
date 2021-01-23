    public class CompositePersonFacade : IPersonFacade
    {
        private readonly IPersonFacade realFacade;
        private readonly IPersonFacade stubFacade;
        public CompositePersonFacade(IPersonFacade realFacade, IPersonFacade stubFacade)
        {
            this.realFacade = realFacade;
            this.stubFacade = stubFacade;
        }
        public List<string> GetPeople()
        {
            return stubFacade.GetPeople();
        }
        public string GetName()
        {
            return realFacade.GetName();
        }
    }
