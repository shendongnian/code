    public void change(string text)
    {
        if (label1.InvokeRequired)
        {
            var a = new Action<string>(change);
            this.Invoke(a, new object[] { text });
        }
        else
        {
            label1.Content = "hello";
        }
    }
