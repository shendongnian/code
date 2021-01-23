    private string file1;
    private DataTable dt;
    private int iTotalLinesOfFile;
    private void button1_Click(object sender, EventArgs e)
        {            
            OpenFileDialog thisDialog = new OpenFileDialog();
    
            if (thisDialog.ShowDialog() == DialogResult.OK)
            {
    			if(dt==null) 
    			{
    				dt== new DataTable();
    			}
    			else
    			{
    				dt.Clear();
    			}
    			file1 = thisDialog.FileName;
                textBox1.Text=file1;
                
    			iTotalLinesOfFile = System.IO.File.ReadAllLines(file1).Length;
                //background worker
                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
                backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
    
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync(); //when you call this the DoWork will start and the code will continue!!
                }
    			//do not let the user to click the button again!!
    			button1.Enabled = false;
    			//you will use this code if you want to cancel the job that Worker does.
                //if (backgroundWorker1.WorkerSupportsCancellation == true)
                //{
                //    backgroundWorker1.CancelAsync();
                //} 
                
            }
        } 
    
     private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {   
    		DataRow dr = null;   
            using (System.IO.StreamReader file = new System.IO.StreamReader(file1))
                {           
                    string line=String.Empty;
                    int lineno = 0;                    
    				int count = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("DISKXFER"))
                        {
    						backgroundWorker1.ReportProgress(count);
                            string dataLine = line.ToString();
                            string[] split = dataLine.Split(',');
                            int result = split.Length;
                            if (lineno == 0)
                            {
                                for (int x = 0; x < result; x++)
                                {
                                    DataColumn dcss = new DataColumn(x.ToString(), Type.GetType("System.String"));
                                    dt.Columns.Add(dcss);
                                }
                                if (dt.Rows.Count <= lineno)
                                {
                                    dr = dt.NewRow();
                                    dt.Rows.Add(dr);                                    
                                }
                                dr = dt.Rows[lineno];                                
                                for (int x = 0; x < result; x++)
                                {
                                    dr[x+1] = split[x];
                                }                                
                            }                                
                            else
                            {
                                if (dt.Rows.Count <= lineno)
                                {
                                    dr = dt.NewRow();
                                    dt.Rows.Add(dr);                                    
                                }
                                dr = dt.Rows[lineno];                               
                                for (int x = 0; x < result; x++)
                                {
                                    dr[x+1] = split[x];
                                }
    
                            }                            
                            lineno += 1;                        
    
                        }
    					count += 1;
                    }
    
                }
        }
    
    	private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    	{
    		dataGridView1.DataSource = dt;
    		button1.Enabled = true;
    	}
    	
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
    		int iCount = e.ProgressPercentage;
    		if(iTotalLinesOfFile==0) return;
    		//progressBar1.Value must not be less than 0 and more than 100
            progressBar1.Value = (iCount / iTotalLinesOfFile) * 100;
        }
