    public event EventHandler<EventArgs> OnButtonClick;
    ...
    protected virtual void OnReady(object sender, EventArgs e) {
        if(OnButtonClick != null) {
            OnButtonClick(sender, e);
        }
    }
