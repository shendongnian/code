    private void Form1_Load(object sender, EventArgs e)
    {
       BackgroundWorker bg1 = new BackgroundWorker();
       bg1.DoWork += new DoWorkEventHandler(method1);
       bg1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(method1_Completed);
       bg1.RunWorkerAsync();
       BackgroundWorker bg2 = new BackgroundWorker();
       bg2.DoWork += new DoWorkEventHandler(method2);
       bg2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(method2_Completed);
       bg2.RunWorkerAsync();
    }
    public void method1(object Sender, DoWorkEventArgs e)
    {
        using (OleDbConnection odbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbfileName + ";Mode=Read"))
        {
            //db manipulation1
        }
    }
    void method1_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
        // Update UI.
    }
    public void method2(object Sender, DoWorkEventArgs e)
    {
        using (OleDbConnection odbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbfileName + ";Mode=Read"))
        {
            //db manipulation1
        }
    }
    void method2_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
        // Update UI.
    }
