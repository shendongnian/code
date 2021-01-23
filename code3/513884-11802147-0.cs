    public CriteriaItemFactory : ICriteriaItemFactory
    {
        private IKernel _kernel;
        public CriteriaItemFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        public ICriteriaItem GetNew()
        {
            return _kernel.Get<ICriteriaItem>();
        }
    }
