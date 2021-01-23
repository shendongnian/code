    public Entity
    {
    	...
    	public void AddTo(IList<Entity> list)
    	{
    		if (list == null)
    		{
    			throw new ArgumentNullException();
    		}
    		
    		list.Add(this);
    		
    		// Do some logic here, as you now know your object
    		// has been added.
    	}
    }
    ...
    entity_.AddTo(entities);
