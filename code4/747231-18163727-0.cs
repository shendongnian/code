    public partial class MyClass
    {
    	partial void OnValidate(System.Data.Linq.ChangeAction action)
    	{
    		if (action == System.Data.Linq.ChangeAction.Insert)
    		{
    		   LastChanged = DateTime.Now;
    		}
    
    	}
    }
