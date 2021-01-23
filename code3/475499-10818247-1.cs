    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public void AddControl(Control control)
		{
			if (InvokeRequired)
			{
				this.Invoke(new Action<Control>(AddControl), new object[] { control });
				return;
			}
			this.Controls.Add(control);
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Task.Factory.StartNew(() =>
				{
					var label = new Label
					{
						Location = new Point(0, 0),
						Text = "hola",
						ForeColor = Color.Black
					};
					this.Invoke(new Action<Control>(AddControl), new object[] { label });
				});
		}
	}
