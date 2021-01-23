    private void button1_MouseEnter(object sender, MouseEventArgs e)
    {
    	BackgroundWorker worker = new BackgroundWorker();
    	worker.DoWork += delegate
    	{
    		for (int i = 0; i < 2; i++)
    		{
    			this.Dispatcher.Invoke((Action)(() => { btn.Content = Convert.ToString(i); }));
    			System.Threading.Thread.Sleep(1000);
    		}                
    	};
    	worker.RunWorkerCompleted += delegate { tekst.Text = "Mouse Enter"; };
    	worker.RunWorkerAsync();
    }
