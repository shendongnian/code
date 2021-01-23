    private void Dowork()
    {
        backgroundWorker1.RunWorkerAsync(comboBox1.Text);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        String selected = (String)e.Argument;
        if (String.IsNullOrEmpty(selected)) return;
        //do stuff
    }
