    public class Test 
    {
       public int Id { get; set;}
       public int field1 { get; set; }  
       
       public override bool Equals(object other)
       {        
       	  Test t = other as Test;
          return this.Id.Equals(t.Id);
       }
       
       public override int GetHashCode()
       {
       		return this.Id.GetHashCode();
       }
    }
