    void DoWork(...)
    {
        YourMethod();
    }
    
    void YourMethod()
    {
        if(yourControl.InvokeRequired)
            yourControl.Invoke((Action)(() => YourMethod()));
        else
        {
            //Access controls
        }
    }
