    public abstract class Form
    {
    	public Form()
    	{
    		Ticket = new LogInfo();
    	}
    	public LogInfo Ticket {get; set;}
    	public int Id {get; set;}
    }
    public class DeleteUsersForm: Form
    {
    	public DeleteUsersForm(IEnumerable<Users> users):base()
    	{
    		this.ViewModel = users;
    	}
    	
    	public IEnumerable<Users> ViewModel {get; set;}
    }
