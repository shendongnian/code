    private void CopiaCartelle()
    {
        if (txtLog.InvokeRequired)
        {
            txtLog.BeginInvoke(new MethodInvoker(delegate { txtLog.AppendText("Copio cartelle in corso..." + Environment.NewLine); }));
        }
        else // this part when Invoke is not required. 
        {
         txtLog.AppendText("Copio cartelle in corso..." + Environment.NewLine);
        }
    }
