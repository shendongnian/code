        public interface IStringRule
    	{
    		bool Matches(string request);
    	}
    	
    	public class AllCapsRule : IStringRule
    	{
    		public bool Matches(string request)
    		{
    			//implement
    		}
    	}
    	
    	public class IsContainingBRule : IStringRule
    	{
    		public bool Matches(string request)
    		{
    			//implement
    		}
    	}
    	
    	public class Verifier
    	{
    		private List<IStringRule> Rules;
    		
    		public Verifier(List<IStringRule> rules)
    		{
    			Rules = rules;
    		}
    
    		public bool IsValid(string request)
    		{
    			return (!Rules.Any(x=>x.Matches(request) == false));
    		}
    	}
