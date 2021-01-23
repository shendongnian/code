    public class MyClass 
    {
        private MyObject myObject;
    
        public void Method1()
        {
            myObject = new MyObject();
        }
    
        public void Method2()
        {
            // might want to  check for null or instantiate myObject in a constructor
            myObject.DoStuff();
        }
    }
