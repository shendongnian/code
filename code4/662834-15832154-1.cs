    public class StringValidator
    {
    	private Dictionary<char, Matcher> Matchers = new Dictionary<char, Matcher>();
    	
    	public StringValidator()
    	{
    		Matchers = new[]{
    			new Matcher('A', c => Char.IsLetter(c)),
    			new Matcher('N', c => Char.IsDigit(c)),
    			new Matcher('X', c => Char.IsLetter(c) || Char.IsDigit(c)),
    			new Matcher('-', c => c == '-')}
    			.ToDictionary(m => m.Flag);
    	}
    	
    	public bool ValidateString(string strForMatching, string strTobeValidated)
    	{
    		if (strForMatching.Length != strTobeValidated.Length)
    			return false;
    			
    		for(int i = 0; i < strTobeValidated.Length; i++)
    		{
    			Matcher matcher = GetMatcher(strForMatching[i]);
    			
    			if (!matcher.DoesMatch(strTobeValidated[i]))
    				return false;
    		}
    		
    		return true;
    	}
    	
    	private Matcher GetMatcher(char flag)
    	{
    		Matcher matcher;
    		
    		if(!Matchers.TryGetValue(flag, out matcher))
    			throw new IndexOutOfRangeException(String.Format("No matcher for character '{0}'", flag));
    			
    		return matcher;
    	}
    }
