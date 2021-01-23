    private void Output(string text)
    {
        if (!txtOutput.Dispatcher.CheckAccess())
        {
             this.txtOutput.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate
             {
                 Output(text); //Call this function again on the correct thread!
             });
             return;
        }
        this.expander.IsExpanded = true;
        txtOutput.AppendText(text);
        txtOutput.AppendText("\r\n");
    }
