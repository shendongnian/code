    [Export(typeof(ITests))]
    public class Example : ITests
    {
    	public string Result(string res)
    	{
    		string resa = res + " dit is door de test gegaan";
    		return resa;
    	}
    }
