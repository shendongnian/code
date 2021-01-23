    public EventListener(myForm theform)
    {
        TheForm = theform;
        TheForm.Changed += (s, e) => this.MyMethod(s, e, "Changed");
    }
    private void MyMethod(object sender, EventArgs e, string eventName)
    {
        string s = "hey, got notified " + sender.GetType().FullName.ToString();
        MessageBox.Show(s);
    }
