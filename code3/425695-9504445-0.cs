    TheTestProcedure.TestInfoEvent += new TestProcedure.InformationEventHandler<string> 
                                 (InfoOccurred);
    
    private void InfoOccurred(Object sender, string s)
    {
        LogMessage(s);
    }
    delegate void LogMessageCallback(string text);
    void LogMessage(String message)
    {
        if (this.textBox1.InvokeRequired)
            this.Invoke(new LogMessageCallback(LogMessage), message);
        else
        {
            this.textBox1.Text = s + Environment.NewLine + this.textBox1.Text;
            if (this.textBox1.Text.Length > 10000)
                this.textBox1.Text = this.textBox1.Text.Remove(1000);
        }
    }
