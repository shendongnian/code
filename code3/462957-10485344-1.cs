    class BusinessLogic : IBusinessLogic
    {
        public IDalFacade DalFacade { get; private set; }
        public BusinessLogic() : this(new DalFacade())
        {}
        public BusinessLogic(IDalFacade dalFacade)
        {
            this.DalFacade = dalFacade;
        }
        public void LogicTheThings()
        {
            this.DalFacade.DoAThing();
        }
    }
