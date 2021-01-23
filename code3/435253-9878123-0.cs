    public partial class DataGridBase : DataGrid
    {
    		public event MouseButtonEventHandler ClickIncludingHandled;
    
            public DataGridBase() : base()
    		{
    			this.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnClickInclHandled), true);
    		}
    
    		private void OnClickInclHandled(object sender, MouseButtonEventArgs e)
    		{
    			if (ClickIncludingHandled != null)
    			{
    				ClickIncludingHandled(sender, e);
    			}
    		}
    }
