    public void LIN_Request_Add_Message(bool isCRCIncluded)           // This Add new line for request based message.
    {
        byte[] dataTX = new byte[10];
        dataTX = myLinTools.LinArrayTXArray();
        DateTime d = DateTime.Now;
        ReqAddMessageThreadProc(isCRCIncluded, dataTX, d);
        
    }
    #endregion
    private void ReqAddMessageThreadProc(bool isCRCIncluded, byte[] dataTX, DateTime d)
    {
        if (this.OutputView.InvokeRequired)
        {
            test1Callback del = new test1Callback(ReqAddMessageThreadProc);
            this.BeginInvoke(del, new object[] { isCRCIncluded, dataTX,d });
            return;
        }
