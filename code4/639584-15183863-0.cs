    private delegate void MYLOGGEREVENT(object sender, EventArgs e);
    private void MyLogger_LogAdded(object sender, EventArgs e)
    {
    if (InvokeRequired)
                {
                    BeginInvoke(new MYLOGGEREVENT(MyLogger_LogAdded), new object[]{sender, e});
                }
    else{
        int length = rtb_logger.TextLength;  // at end of text
        string prefix = string.Format("{0:d3}: ", ++logindex);
        string ToAppend = prefix + MyLogger.GetLastLog();
        rtb_logger.AppendText(ToAppend);
        if (ToAppend.Contains("Alert -"))
        {
            rtb_logger.SelectionStart = length;
            rtb_logger.SelectionLength = ToAppend.Length;
            rtb_logger.SelectionColor = Color.Red;
        }
        rtb_logger.AppendText(Environment.NewLine);
        rtb_logger.SelectionStart = rtb_logger.TextLength;
        rtb_logger.ScrollToCaret();
        EnableControls();
    }
    }
