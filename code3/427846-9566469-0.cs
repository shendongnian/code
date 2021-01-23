    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var docText = (string)e.Argument;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        var docText = webBrowser1.Document.Body.InnerText;
        backgroundWorker1.RunWorkerAsync(docText);
    }
