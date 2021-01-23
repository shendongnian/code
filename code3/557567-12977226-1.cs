    public event EventHandler MyEvent;
    private void button1_Click(object sender, EventArgs e)
    {
        if (MyEvent!= null)
            MyEvent(this, EventArgs.Empty);
    }
