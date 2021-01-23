    public class DistinctCustomer
    {
       public int CustomerId { get; set; }
       public string CustomerName { get; set; }
       
       public override bool Equals(object obj)
       {
       		if (ReferenceEquals(obj, null)) return false;
    		if (ReferenceEquals(this, obj)) return true;
    		
    		var other = obj as DistinctCustomer;
    		
    		if (other == null) return false;
    		
    		return CustomerId == other.CustomerId;
       }
       
       public override int GetHashCode()
       {
       		return CustomerId.GetHashCode();
       }
    }
