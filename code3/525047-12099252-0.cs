	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			progressBar1.Maximum = 3;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
		}
		private void button1_Click(object sender, EventArgs e)
		{
				 progressBar1.Value = 0; 
				axMozillaBrowser1.Navigate(textBox1.Text);
		}
		private void webBrowser2_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			if ( progressBar1.Value < 3 )
			{
				axMozillaBrowser1.Navigate(textBox1.Text);
				progressBar1.Value = progressBar1.Value + 1; 
			}
		}
	}
