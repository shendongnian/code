    public class YourServiceLayer
    {
    	public YourEntity Update(string userName, YourEntity entity)
    	{
    		// Check user has rights to edit the entity (if necessary)
    		if (this.CanUpdate(userName, entity.ID))
    		{
    			// Gets actual entity from DB
    			var yourDbEntity = this.GetByID(entity.ID);
    			
    			// Updates each property manually
    			yourDbEntity.Field1 = entity.Field1;
    			....
    			
    			// Saves to DB
    			this.Save(yourDbEntity);
    			return yourDbEntity;
    		}
    		else
    		{
    			// Security exception
    			throw new CustomSecurityException(...);
    		}	
    	}
    	
    	public bool CanUpdate(string userName, long entityID)
    	{
    		// Insert logic here
    		return ....;
    	}
    	
    	...
    }
