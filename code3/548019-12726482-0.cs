    public class RelayComparer<T> : IEqualityComparer<T>
    {
	private Func<T, T, bool> equals;
	private Func<T, int> getHashCode;  
	
	public RelayComparer(Func<T, T, bool> equals, Func<T,int> getHashCode)
	{
	  this.equals = equals;
	  this.getHashCode = getHashCode;
	}
	
	public bool Equals(T x, T y)
	{
	  return equals(x, y);
	}
	public int GetHashCode(T obj)
	{
	  return getHashCode(obj);
	}
    }
    
    var comparer = new RelayComparer<Address>(
 	(lhs, rhs) => lhs.Province == rhs.Province && lhs.City == rhs.City, 
		  t => t.Province.GetHashCode() + t.City.GetHashCode());
			 
    myList.Distinct(comparer);
