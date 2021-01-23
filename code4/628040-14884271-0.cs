	public partial class Form1 : Form
	{
		Timer loop;
		
		public Form1()
		{
			InitializeComponent();
			this.loop = new System.Windows.Forms.Timer();
			loop.Interval = 50;
			loop.Tick += new EventHandler(UpdateUI);
			loop.Start();
		}
		void UpdateUI(object sender, EventArgs e)
		{
			//ADD TO LIST ON USER INTERFACE
		}
	}
