    class SomeClass 
    {
        public int SomeValue;
        public SomeClass() 
        {
        }
    }
    class SomeClassFactory 
    {
        public SomeClass CreateSomeClass() 
        {
            SomeClass obj = new SomeClass();
            obj.SomeValue = ConfigManager.GetDefaultInt("SomeValue");
        }
    }
