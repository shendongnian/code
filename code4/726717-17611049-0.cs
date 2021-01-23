		public Form1()
		{
			InitializeComponent();
			timer1.Enabled = true;
			timer1.Interval = (5*1000);
			timer1.Tick += SendSMS;
		}
		private void SendSMS(object sender, EventArgs e)
		{
			timer1.Stop();
			// Code to send SMS
			timer1.Start();
		}
