    public abstract class UKey
    {	           
        public Guid Key{ get; set; }
	    public abstract bool FindKey(Guid g);
    }
    public class Test : UKey
    {
        public Int64? CityId  { get; set; }
        public Test2  Test2{ get; set; }
	    public override bool FindKey(Guid g){
	       	return Key == g || (Test2!= null && Test2.FindKey(g));
	    }	
    }
    /*etc.. implement the FindKey method on all you derived classes*/
