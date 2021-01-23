    public class Factory
    {
    	private Dictionary<Type, Func<object>> builders = new Dictionary<Type, Func<object>>
    	{
    		{ typeof(IAddressModel), BuildAddressModel },
    		{ typeof(IUserModel), BuildUserModel }
    	};
    
    	public T Build<T>()
    	{
    		Func<object> buildFunc;
    		if (builders.TryGetValue(typeof(T), out buildFunc))
    		{
    			return (T)buildFunc();
    		}
    		else throw new ArgumentException("No builder for type " + typeof(T).Name);
    	}
    
    	private static IAddressModel BuildAddressModel()
    	{
    		return new AddressModel();
    	}
    
    	private static IUserModel BuildUserModel()
    	{
    		return new UserModel();
    	}
    }
