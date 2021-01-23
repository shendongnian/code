    protected virtual void OnDataPopulated()
    {
        if (DataPopulated != null)
            DataPopulated(this, EventArgs.Empty);
    }
