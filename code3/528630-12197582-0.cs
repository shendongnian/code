    public class bar
    {
        //  Original constructor
        int value { get; set; }
        public bar(int i)
        {
            this.value = i;    
        }       
    }
    public abstract class foobar : bar
    {
        int value {get; set;}
        protected foobar(int i) : base(i)
        {
          value = i;
        }        
    }
    public class foo : foobar
    {
        //  New constructor
        protected foo(int i)
            : base(i)
        {
        }
    }
  
