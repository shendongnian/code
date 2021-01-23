    public class Foo
    {
     public virtual int someInt {get; set;}
     public virtual IList<string> this[int key] 
     {
     	get{ return null; }
    	set 
    	{
    	}
     }
    }
