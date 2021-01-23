    void ValidateInput()
    {
        SetisValidatingState(true);
    
        System.Threading.Thread workThread = new System.Threading.Thread(delegate() 
            { 
                ////
                // Validate here
                ////
                SetisValidatingState(false);
            });
        workThread.Start();
    }
    
    
    delegate void SetisValidatingStateDelegate(bool state);
    void SetisValidatingState(bool state)
    {
        if (InvokeRequired)
        {
            Invoke(new SetisValidatingStateDelegate(SetisValidatingState), new object[] { state });
            return;
        }
    
        textBox1.AcceptsTabs = textBox2.AcceptsTabs = textBox3.AcceptsTabs = textBox4.AcceptsTabs = !state; // Disable tab while validating = true
        progressBar.visible = state; // show progress while validating = true
    }
