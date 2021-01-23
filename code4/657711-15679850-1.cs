    private void btnStart_Click(object sender, EventArgs e)
    {
        ProgressBar pb = new ProgressBar();
        if (pbCounter <= 10)
        {
            pb.Width = txtUrl.Width;
            flowLayoutPanel1.Controls.Add(pb);
            pbCounter++;
    
            MyBackgroundWorker backgroundWorker1 = new MyBackgroundWorker();
            backgroundWorker1.pbProgress = pb;
    
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
    
            backgroundWorker1.RunWorkerAsync();
        }
    }
