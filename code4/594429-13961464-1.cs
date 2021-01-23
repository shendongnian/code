    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string input_ip_r = "";
        this.Invoke(new Action(() => 
        {
            // Don't know what "lc" is (a loop variable?)
            input_ip_r = listView1.Items[lc].SubItems[1].Text;
        }));
    }
    
