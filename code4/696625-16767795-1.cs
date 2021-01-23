    private StreamReader sr;
    public void Open()
    {
    	Timer timer = new Timer();
    	timer.Interval = 1000;
    	timer.Tick += new EventHandler(timer_Tick);
    	timer.Enabled = true;
          timer.Start();
    	using (this.sr = new StreamReader(openFileDialog1.FileName))
    	{
    		using (CachedCsvReader csv = new CachedCsvReader(sr, true))
    		{
    			dataGridView1.DataSource = csv;
    		}
    	}
          timer.Stop();
    	timer.Enabled = false;
    	timer.Tick -= new EventHandler(timer_Tick);
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
    	if (null != this.sr)
    	{
    		double progress = (double)sr.BaseStream.Position / (double)sr.BaseStream.Length;
    		progressBar1.Value = (int)progress * 100;
    	}
    }
