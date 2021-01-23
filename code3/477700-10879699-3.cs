    public class Validator
    {
    	IValidatorEngine _engine;
    	
    	public static void Assign(IValidatorEngine engine)
    	{
    		_engine = engine;
    	}
    	
    	public static IValidatorEngine Current { get { return _engine; } }
    }
