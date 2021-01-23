    public class RoleRelationship<T>
    {
    	public RoleRelationship(T firstRole, T secondRole)
    	{
    		if (firstRole.OccupiedBy == null || secondRole.OccupiedBy == null)
    			throw new Exception("One or both of the Role parameters is not occupied by a party.");
    
    		// Connect this relationship with the two roles.
    		_FirstRole = firstRole;
    		_SecondRole = secondRole;
    
    		_SecondRole.ProvisionRelationship<T>(_FirstRole);
    	}
    }
