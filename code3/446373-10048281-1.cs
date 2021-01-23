    public BusinessClass
    {
        private IDataProvider dataProvider;
    
        public BusinessClass()
        {
            dataProvider = new DBDataProvider();
        }
    
        public BusinessClass(IDataProvider provider)
        {
            dataProvider = provider;
        }
    
        public void doBusinessStuff()
        {
            dataProvider.getData(); 
            //Do something with data.
        }
    
    }
