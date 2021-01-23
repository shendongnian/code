   	private void button1_Click(object sender, EventArgs e)
	{
	   for (int i = 0; i < 3; i++)
		 yourFunction_bw(i);
	 }
	private BackgroundWorker gBgwDownload;
	private void yourFunction_bw(int i)
	{
		// Create a background thread
		gBgwDownload = new BackgroundWorker(); // added this line will fix problem 
		gBgwDownload.DoWork += bgwDownload_DoWork;
		gBgwDownload.RunWorkerAsync(i);
	}
	private void bgwDownload_DoWork(object sender, DoWorkEventArgs e)
	{
	  int stre = (int)e.Argument;
	  MessageBox.Show(stre.ToString ()); // time taken process can be added here
	}
