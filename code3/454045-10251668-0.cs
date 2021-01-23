    public class Foo
    {
        // public method 
        public void Method1()
        {
        }
    
        public static void Data2()
        {
            // call public method from static method
            new Foo().Method1();
        
        }
    }
