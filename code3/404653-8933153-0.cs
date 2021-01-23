    public string Test
    {
        set
        { 
            test = value; 
            rtxt_chatLog.Text = test;
        }
        get { return test; }
    }
