    public void DoWork()
    {
        button1.Invoke(new Action(() =>
        {
            button1.Text = "Hello there";
        }));            
    }
    
