    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync("https://facebook.com"); // start async operation
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = simpleRequest(e.Argument.ToString()); // set result in async operation
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            // show result here
            // or access/manage result here
           Debug.WriteLine(e.Result.ToString()); 
        }
        else
        {
            // manage/show error
        }
    }
    private String simpleRequest(String url)
    {
         // your code goes here
    }
