    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Thread t = new Thread(new ThreadStart(TestThread));
			t.Start();
		}
		private void TestThread()
		{
			for (int i = 0; i < 10; i++)
			{
				UpdateCounter(i);
				Thread.Sleep(1000);
			}
		}
		private void UpdateCounter(int i)
		{
			
			if (label1.InvokeRequired)
			{
				label1.Invoke(new ThreadStart(delegate { UpdateCounter(i); }));
			}
			else
			{
				label1.Text = i.ToString();
			}
		}
	}
