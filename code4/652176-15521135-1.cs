    public void TextBox1_Validating(object sender, CancelEventArgs args)
    {
        // handle the event
    }
    
    
    public void RegisterEvent()
    {
        CancelEventHandler handler = (CancelEventHandler)Delegate.CreateDelegate(
            typeof(CancelEventHandler), 
            this,
            "TextBox1_Validating");
        textBox1.Validating += handler;
    }
