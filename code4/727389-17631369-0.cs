    void SomeAsyncMethod()
    {
        // Do some work             
    
        if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)(() =>
                {
                    DoUpdateUI();
    
                }
            ));
        }
        else
        {
            DoUpdateUI();
        }
    }
    
    void DoUpdateUI()
    {
        // Your UI update code here
    }
