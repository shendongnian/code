    protected virtual void OnActive(EventArgs e)
    {
        EventHandler<EventArgs> active = Active;
        if (active != null)
        {
            active(this, e);
        }
    }
    protected virtual void OnInactive(EventArgs e)
    {
        EventHandler<EventArgs> inactive = Inactive;
        if (inactive != null)
        {
            inactive(this, e);
        }
    }
