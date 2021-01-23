    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog fDialog = new OpenFileDialog();
        //...
        if (fDialog.ShowDialog() == DialogResult.OK)
            backgroundWorker1.RunWorkerAsync(fDialog.FileName);
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string fileName = (string)e.Argument;
        // fill foos from excel
        List<Foo> foos = excelOperation(fileName);    
        e.Result = foos;
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, 
                                                      RunWorkerCompletedEventArgs e)
    {
        dataGridView1.DataSource = (List<Foo>)e.Result;
    }
