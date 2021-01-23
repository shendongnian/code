    public delegate void OkClickedHandler(object sender, EventArgs e);
    public event OkClickedHandler OkClicked;
    private void OkButton_Click(object sender, EventArgs e)
    {
        // Make sure someone is listening to event
        if (OkClicked == null) return;
        OkClicked(sender, e);
        this.Hide();       
    }
