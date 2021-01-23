    class DataBuilder
    {
        public DataBuilder(IResources resources)
        {
            _resources = resources;
        }
    
        public void PreLoadExpensiveData()
        {
            InitializeProviderList();
            // etc
        }
    
        private void InitializeProviderList()
        {
            // Put whatever was in get_ProviderList into here 
            // and make the property return just the field.
        }
    }
