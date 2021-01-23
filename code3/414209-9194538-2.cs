    private delegate void MyDelegate(string s);
    public void UpdateControl(Control targetControl, string text)
    {
        if (targetControl.InvokeRequired)
        {
            // THIS IS STILL THE IN THE CONTEXT OF THE THREAD
            MyDelegate call = new MyDelegate(UpdateControl);
            targetControl.Invoke(call, new object[] { text });
        }
        else
        {
            // do control stuff
            // THIS IS IN THE CONTEXT OF THE UI THREAD
        }
    }
