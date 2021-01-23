    // the canonical form (C# consumer)
    
    public delegate void ControlStringConsumer(Control control, string text);  // defines a delegate type
    
    public void SetText(Control control, string text) {
        if (control.InvokeRequired) {
            control.Invoke(new ControlStringConsumer(SetText), new object[]{control, text});  // invoking itself
        } else {
            control.Text=text;      // the "functional part", executing only on the main thread
        }
    }
