    public class Group
    {
    	public string Name { get; private set; }
    	
    	public class Admin
    	{
    		public Group ReviseGroupName (Group group, string revisedName)
    		{
    			group.Name = revisedName;
    			return group;
    		}
    	}
    }
