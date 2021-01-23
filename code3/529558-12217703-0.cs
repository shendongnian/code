    public event EventHandler ThresholdReached;
    
    protected virtual void OnThresholdReached(EventArgs e)
    {
        if (ThresholdReached != null)
        {
            ThresholdReached(this, e);
        }
    }
