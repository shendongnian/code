    	protected void Page_Load(object sender, EventArgs e)
		{
			InsertControls();
		}
		private void InsertControls()
		{
			TextBox textBox = new TextBox();
			textBox.ID = "textBox1";
			textBox.Text = "Cool Beans";
			controlPanel.Controls.Add(textBox);
			TextBox locatedTextBox = TraverseControlTree(controlPanel, "textBox1") as TextBox;
		}
		public static Control TraverseControlTree(Control root, string Id)
		{
			if (root.ID == Id) { return root; }
			foreach (Control Ctl in root.Controls)
			{
				Control control = TraverseControlTree(Ctl, Id);
				if (control != null) { return control; }
			}
			return null;
		}
