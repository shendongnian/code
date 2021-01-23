    interface IIdentifier
    {
    	string Name {get;}
    }
    
    abstract class Identifier<T> : IIdentifier
    {
    	private readonly string _name;
    	private readonly T _id;
    	public string Name {get;set;}
    	
    	protected Identifier(string name, T id)
    	{
    		_id = id;
    		_name = name;
    	}
    }
    
    class GuidIdentifier : Identifier<Guid>
    {
    	public GuidIdentifier(string name, Guid identifier)
    		:base(name, identifier)
    	{
    		//?
    	}
    }
    
    class UserOptions
    {
    	private IEnumerable<IIdentifier> _identifiers;
    
    	public IEnumerable<IIdentifier> Identifiers {get {return _identifiers;}}
    	
    	public IIdentifier Selected {get;set;}
    	
    	public UserOptions(IEnumerable<IIdentifier> identifiers)
    	{
    		_identifiers = identifiers;
    	}
    }	
