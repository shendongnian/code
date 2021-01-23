    public event EventHandler<EventArgs> Control1ButtonClicked;
    private void OnClicked()
    {
        var handler = Control1ButtonClicked;
        if (handler != null)
        {
            handler(this, new EventArgs());
        }
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        OnClicked();     
    }
