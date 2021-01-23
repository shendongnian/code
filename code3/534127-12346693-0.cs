    private void ProcessTimerEvent(object obj)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<object>(this.ProcessTimerEvent), obj);
        }
        else
        {
             this.Show();
        }
    }
