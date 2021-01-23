    public void button1_Click(object sender)
    {
        List<string> files = listBoxFiles.Items.OfType<string>().ToList();
        string key = textBoxFileToSearch.Text;
        backgroundWorkerSearch.RunWorkerAsync(new Tupple<List<string>,string>(files, key));
    }
    void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
    {
         var state = e.Argument as Tupple<List<string>,string>;
         List<string> files = state.Item1;
         string key = state.Item2;
         // You can now access the needed data.
         List<string> searchResult = new List<string>();
         // ...
         e.Result = searchResult;
    }
    void backgroundWorkerSearch_RunWorkerCompleted(RunWorkerCompletedEventArgs e)
    {
         List<string> searchResult = e.Result;
         // Show result in the UI thread.
    } 
