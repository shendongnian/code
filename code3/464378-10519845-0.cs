    public class bar
    {
        foo test = new foo(this); // will not work
    
        public bar()
        {
            foo f = new foo(this); //will work.            
        }
    }
    
    public class foo 
    {
    
        public foo()
        { }
    
        public foo(bar barAsParameter)
        {
        }
    }
