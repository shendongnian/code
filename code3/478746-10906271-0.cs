	public partial class Form1 : Form
	{
		System.Timers.Timer timer = new System.Timers.Timer(100);
		public Form1()
		{
			InitializeComponent();
			timer.AutoReset = true;
			timer.SynchronizingObject = this;
			timer.Elapsed += timer_Elapsed;
		}
		void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this.Height += 5;
			if (this.Height -10 > ErrorsGrid.Bottom)
				timer.Stop();
		}
		void button1_Click(object sender, EventArgs e)
		{
			timer.Start();
		}
	}
