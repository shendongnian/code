    // In a constructor or something
    timer = new System.Windows.Forms.Timer();
    timer.Interval = 1000; // 1000 milliseconds
    timer.Tick += (s, e) => 
    {
        button.Enabled = true;
        timer.Stop();
    };
    // ...
    
    void OnButtonClick()
    {
        button.Enable = false;
        timer.Start();
    
        // Do whatever the button does...
    }
