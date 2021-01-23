    public  class  BaseClass
    {
    	public virtual int customerid {get; set;}
    	
    	public void printname()
    	{
    	   customerid = 1;
    	   customerid.Dump();
    	}
    }
    public class DerivedClass : BaseClass
    {
        public new string customerid {get; set;}
        public void PrintCustomerID()
        {
            customerid = "jshwedeX"; 
            customerid.Dump();
        }
    }
