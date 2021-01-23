    private void Output(string text)
    {
        if (txtOutput.Dispatcher.CheckAccess())
        {
            this.expander.IsExpanded = true;
            txtOutput.AppendText(text);
            txtOutput.AppendText("\r\n");
        }
        else
        {
            this.txtOutput.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate
             {
                 this.expander.IsExpanded = true;
                 //  txtOutput.AppendText += text Environment.NewLine;
                 txtOutput.AppendText(text);
                 txtOutput.AppendText("\r\n");
             }); 
        }
    }
