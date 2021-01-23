    public class ComponentType
    {
    	public Type UnderlyingType { get; private set; }
    	
    	private ComponentType(Type underlyingType)
    	{
    		this.UnderlyingType = underlyingType;
    	}
    	
    	public static ComponentType Create<T>() where T : IComponent
    	{
    		return new ComponentType(typeof(T));
    	}
    }
