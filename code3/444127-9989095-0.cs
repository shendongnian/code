	class StatusChangedEventArgs : EventArgs
	{
		public string Text { get; set; }
	}
    partial class MyControl : UserControl
    {
		public event EventHandler<StatusChangedEventArgs> StatusChanged = delegate { };
		public void RaiseStatusChanged( string message )
		{
			StatusChanged( this, new StatusChangedEventArgs { Text = "message" } );
		}
    }
