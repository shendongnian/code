    public interface IQuery<T>
    {
    	IEnumerable<T> Execute(IContext context);
    }
    
    public class FindAllUsersInGroupQuery : IQuery<User>
    {
    	public int GroupId {get; set;}
    	
    	IEnumerable<User> Execute(IContext context)
    	{
    		return context.DoSomeQueryForGettingUsers(GroupId);
    	}
    }
