    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        // This is called on the worker thread
        UpdateLabel((string)e.Argument));
          ...more work here...
    }
    void UpdateLabel(string s)
    {
        if (this.label1.InvokeRequired)
        {
            // It's on a different thread, so use Invoke.
            this.BeginInvoke (new MethodInvoker(() => UpdateLabel(s));
        }
        else
        {
            // It's on the same thread, no need for Invoke
            this.label1.Text = s;
        }
    }
