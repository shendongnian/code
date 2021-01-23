    public event EventHandler ButtonClicked;
    protected virtual void OnButtonClicked()
    {
        var handler = ButtonClicked;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
    void button_Clicked(object sender, EventArgs e)
    {
        OnButtonClicked(); // Bubble the event
    }
