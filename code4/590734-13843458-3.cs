    public event EventHandler SomethingHappened;
    
    public string Data
    {
       get { return textBoxData.Text; }
    }
    
    private void SomeButton_Click(object sender, EventArgs e)
    {
        if (SomethingHappened != null)
            SomethingHappened(this, EventArgs.Empty);
    }
