    private delegate T Method(ProgressBarCallBackInterface callingform, params object[] argsobject);
    private void frmProgress_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(FormTitle))
        {
            lblSampleTitle.Text = FormTitle;
            this.Text = FormTitle;
        }
        else
        {
            lblSampleTitle.Text = string.Empty;
            this.Text = string.Empty;
        }
        bgWorkerThread.RunWorkerAsync();
    }
    private void bgWorkerThread_DoWork(object sender, DoWorkEventArgs e)
    {
        Delegate method = Delegate.CreateDelegate(typeof(Method), instanceOfClassHavingTheFunction, FullFunctionName, true, true);
        if (method != null)
        {
            ReturnValue = ((Method)method)(this, Parameters);
        }
    }
    public void ReportProgress(int percentage, string statusText)
    {
        lblProgress.SetPropertyThreadSafe(() => lblProgress.Text, statusText);
        bgWorkerThread.ReportProgress(percentage);
    }
