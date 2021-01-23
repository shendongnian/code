    public partial class SomeView : UserControl, IHandle<ControlClosedEvent>
    {
    	public void Handle( ControlClosedEvent message )
    	{
    		// ugly way of setting the text box as focused
    		SomeTextBox.Focus();
    	}
    }
