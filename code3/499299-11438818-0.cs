    public double Zoom
    {
        get { return this.zoom; }
        set
        {
            if (this.zoom != value)
            {
                this.zoom = value;
                this.RaisePropertyChanged(() => this.Zoom);
            }
        }
    }
    private void DoSomeCalculation()
    {
        // can use this.zoom here
    }
