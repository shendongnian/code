	// Change YourBaseControl by a meaningful name
	public partial class YourBaseControl : BaseUserControl 
	{ 
		protected override void OnLoad(EventArgs e)
		{	
			this.Value = myCustomService.GetBoolValue();  
			///More code here...
			base.OnLoad(e);
		}
	}   
	
	public partial class MyControl2 : YourBaseControl
	{
	   ...
	}
	
	public partial class MyControl3 : YourBaseControl
	{
	   ...
	}	
