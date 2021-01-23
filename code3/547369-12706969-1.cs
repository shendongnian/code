    FileInfo[] files;
    void _background_DoWork(object sender, DoWorkEventArgs e)
    {
        files = new DirectoryInfo(System.IO.Path.GetTempPath()).GetFiles();
    }
    
    void _background_RunWorkerCompleted(object sen, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            MessageBox.Show("Cancelled");
        }
        else if (e.Error != null)
        {
            MessageBox.Show("Exception Thrown");
        }
        else 
        { 
             foreach (FileInfo fi in files)
             {
                  dataGrid1.Items.Add(fi);           
             }
        }
    }
