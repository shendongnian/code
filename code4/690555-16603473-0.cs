    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
       e.Result = bind((string)e.Argument, worker, e);//e.result stored the return value from bind
    }
        
    string bind(string sss, BackgroundWorker worker, DoWorkEventArgs e)
    {
        //Your code . . . .
        return sss;
    }
    
    private void button6_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync("hai");//when the user click button6 backgroundWorker1_DoWork start the function 
    }
