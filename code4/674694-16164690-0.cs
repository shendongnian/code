    public interface ICondition
    {
    	bool IsMatch(string input);
    	string GetMessage();
    }
    
    public class StartsWithTest : ICondition
    {
    	public bool IsMatch(string input)
    	{
    		return input.StartsWith("x");
    	}	
    
    	public string GetMessage()
    	{
    		return "string starts with an X";
    	}
    }
    
    
    public class TestInput
    {
    	
    	private readonly IList<ICondition> _conditions;
    
    	public TestInput()
    	{
    		_conditions = new List<ICondition>();
    		
    		_conditions.Add(new StartsWithTest());
    		//etc etc
    	}
    
    	public string Test(string input)
    	{
    		var match = _conditions.FirstOrDefault(c => c.IsMatch(input));
    
    		if (match != null)
    			return match.GetMessage();
    		else
    			return string.Empty;
    	}
    }
