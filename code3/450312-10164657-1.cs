    public partial class dCB_Props : UserControl
    {
    	static dCB_Props()
    	{
    		...
    		CommandManager.RegisterClassCommandBinding(
    			typeof(dCB_Props),
    			new CommandBinding(EditDeleteItem.EditCommand, OnEditCommandExecuted));
    		CommandManager.RegisterClassCommandBinding(
    			typeof(dCB_Props),
    			new CommandBinding(EditDeleteItem.DeleteCommand, OnDeleteCommandExecuted));
    		...
    	}
    	...
    }
