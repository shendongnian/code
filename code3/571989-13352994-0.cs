    public class CardComparer : IEqualityComparer<CreditCard>
    {
    	private readonly Regex re = new Regex(@"\s+");
    	
    	public bool Equals(CreditCard x, CreditCard y)
    	{
    		return re.Replace(x.Number, "") == re.Replace(y.Number, "");
    	}
    
    	public int GetHashCode(CreditCard obj)
    	{
    		return re.Replace(obj.Number, "").GetHashCode();
    	}
    }
