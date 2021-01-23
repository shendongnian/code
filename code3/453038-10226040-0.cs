    public class Customer 
    {
        protected string telNumber =string.Empty; 
        public virtual string TelephoneNumber 
        {
    	  get { return telNumber ; }
    	  set {telNumber =value;}
    	}
    }
    
    public class Worker : Customer 
    {
       public override string TelephoneNumber 
       {
           get 
           {
    	      Console.WriteLine("Worker");
    	      return telNumber ; 
           }
    	   set {telNumber = value;}
       }
    }
