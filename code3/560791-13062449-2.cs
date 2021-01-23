    void button1_Click(object sender, EventArgs e)
    {
       var worker = new BackgroundWorker();
       worker.DoWork += (s,e) =>
       {
           // Do some work.
       };
       worker.RunWorkerCompleted += (s,e) =>
       {
           // Update the UI.
       }
       worker.RunWorkerAsync();
    }
