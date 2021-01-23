    public interface IEntity<T> : IEntity
    {
    	new T GetThis();
    }
    
    public interface IEntity
    {
    	object GetThis();
    }
