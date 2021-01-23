    class BaseClass
    {
        public BaseClass()
        {
    
        }
        public BaseClass(string argument1)
        {
             Init(argument1);
        }
    
        public void Init(string argument1)
        {
            //...
        }
    }
    
    class ExampleClass : BaseClass
    {
        public ExampleClass()
        {
        }
    }
