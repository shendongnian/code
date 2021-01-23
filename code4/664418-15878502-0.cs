    public class Point
    {
    	public Point(string amountUnit)
    	{
    		if (amountUnit == null)
    		{
    			throw new ArgumentNullException("amountUnit");
    		}
    
    		if (amountUnit.ToLower().Contains("x"))
    		{
    			string[] amount = amountUnit.Split('x');
    			this.X = amount[0].Trim();
    			this.Y = amount[1].Trim();
    		}
    		else
    		{
    			this.X = "1";
    			this.Y = amountUnit.Trim();
    		}
    	}
    
    	string X { get; private set; }
    	string Y { get; private set; }
    }
