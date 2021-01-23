    /// <summary>
    /// Generated Code for MyClass
    /// </summary>
    public partial class MyClass
    {
        private partial void MyMethodImpl();
        public void MyMethod()
        {
            //Do work specific to MyClass
    		
    		MyMethodImpl();
        }
    }
    
    /// <summary>
    /// Non-generated extension for MyClass
    /// </summary>
    public partial class MyClass
    {
        public void MyMethodImpl()
        {
            //Do some other work
        }
    }
