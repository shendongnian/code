    private delegate void InvokeUpdateText(String theText);
    private void UpdateText(String theText)
    {
        if (InvokeRequired)
        {
            try { Invoke(new InvokeUpdateText(UpdateText), theText); }
            catch { }
            return;
        }
        label1.Text = theText;
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        WebClient wc = new WebClient();
        UpdateText("http://example.org/version.txt");
    }
