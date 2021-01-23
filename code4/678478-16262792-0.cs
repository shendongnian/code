	public static void startpage(Form form)
	{
		try
		{
			var Tip = new Label() { Text = "Input instance name",
				Location = new Point(50, 50), AutoSize = true };
			var InstanceInput = new TextBox() { Text = "INSTANCENAME", 
				Location = new Point(100, 70), MaxLength = 1000, Width = 200,
			BorderStyle=BorderStyle.FixedSingle};
			
			var StartConnection = new LinkLabel() { Text = "Connect", 
				Location = new Point(50, 100), AutoSize = true, Tag = InstanceInput };
			
			StartConnection.Click += new EventHandler(nextpage);
			Helpers.AddControlsOnForm(form,
				new Control[] {Tip,StartConnection,InstanceInput });
		}
		catch(Exception ex) 
		{ MessageBox.Show("Error occured. {0}",ex.Message.ToString()); }
	}
	
	public static void nextpage(Object sender, EventArgs e)
	{
	   var text = ((sender as LinkLabel).Tag as TextBox).Text;
	}
