    public class ExtendedA : A 
    { 
        public void DoSomething() 
        { 
            var a = new A();
 
            // access level error
            a.Something = .... 
        } 
    } 
