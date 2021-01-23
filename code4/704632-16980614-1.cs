    public class Test 
    {
       public int Id { get; set;}
       public int field1 { get; set; }  
       
       public override bool Equals(object other)
       {        
    		Test t = other as Test;
    		return (t != null) ? Id.Equals(t.Id) : false;
       }
       
       public override int GetHashCode()
       {
       		return this.Id.GetHashCode();
       }
    }
