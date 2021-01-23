    private delegate void MyDelegate(string s);
    public void UpdateControl(Control targetControl, string text)
    {
        if (targetControl.InvokeRequired)
        {
            MyDelegate call = new MyDelegate(UpdateControl);
            targetControl.Invoke(call, new object[] { text });
        }
        else
        {
            // do control stuff
        }
    }
