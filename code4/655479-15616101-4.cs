    void ValidateInput()
    {
        SetEnabledState(false);
    
        System.Threading.Thread workThread = new System.Threading.Thread(delegate() 
            { 
                ////
                // Validate here
                ////
                SetEnabledState(true);
            });
        workThread.Start();
    }
    
    
    delegate void SetEnabledStateDelegate(bool state);
    void SetEnabledState(bool state)
    {
        if (InvokeRequired)
        {
            Invoke(new SetEnabledStateDelegate(SetEnabledState), new object[] { state });
            return;
        }
    
        textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = state;
    }
