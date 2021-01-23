	public partial class Form1 : Form
	{
		BackgroundWorker _bw = new BackgroundWorker();
		CalledClass call = new CalledClass();
		public Form1()
		{
			InitializeComponent();
			
			bw.DoWork += bw_DoWork;
			bw_ProgressChanged += bw_ProgressChanged;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (bw.IsBusy != true)
			{
				bw.RunWorkerAsync();
			}
		}
		
		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			call.Call_UpdateBox();
		}
		
		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			textBox1.Text = "hello";
	        // Here you can access some progress property from CalledClass in order to monitor and inform progress
		}
	}
