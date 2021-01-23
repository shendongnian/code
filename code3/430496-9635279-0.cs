	public partial class EMailListControl : UserControl
	{
		public EMailListControl()
		{
			InitializeComponent();
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.WrapContents = false;
			flowLayoutPanel1.AutoScroll = true;
			flowLayoutPanel1.Resize += new EventHandler( flowLayoutPanel1_Resize );
		}
		private void flowLayoutPanel1_Resize( object sender, EventArgs e )
		{
			foreach ( Control control in flowLayoutPanel1.Controls )
			{
				UpdateControlWidth(control);
			}
		}
		private void UpdateControlWidth(Control control)
		{
 			control.Width = flowLayoutPanel1.Width - (flowLayoutPanel1.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
		}
		public void AddEmailItem( EmailItemControl control )
		{
			UpdateControlWidth(control);
			flowLayoutPanel1.Controls.Add(control);
		}
	}
