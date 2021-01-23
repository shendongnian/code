    class SomeClass 
    {
        public int SomeValue;
        public SomeClass() 
        {
            // Check the config for some value
            SomeValue = ConfigManager.GetDefaultInt("SomeValue");
        }
    }
