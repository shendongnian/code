    using System;
    
    public class Example
    {
    
        public void Method1(Action hello)
        {
            // Call passed action.
            hello();
        }
    
        public void Method2()
        {
            // Do something here
        }
    
        public void Method3()
        {
            Method1(Method2);
        }
    }
