    public bool Enabled
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get
        {
            return this.enabled;
        }
        set
        {
            if (base.DesignMode)
            {
                this.delayedEnable = value;
                this.enabled = value;
            }
            else if (this.initializing)
            {
                this.delayedEnable = value;
            }
            else if (this.enabled != value)
            {
                if (!value)
                {
                    if (this.timer != null)
                    {
                        this.cookie = null;
                        this.timer.Dispose();
                        this.timer = null;
                    }
                    this.enabled = value;
                }
                else
                {
                    this.enabled = value;
                    if (this.timer == null)
                    {
                        if (this.disposed)
                        {
                            throw new ObjectDisposedException(base.GetType().Name);
                        }
                        int dueTime = (int) Math.Ceiling(this.interval);
                        this.cookie = new object();
                        this.timer = new Timer(this.callback, this.cookie, dueTime, this.autoReset ? dueTime : 0xffffffff);
                    }
                    else
                    {
                        this.UpdateTimer();
                    }
                }
            }
        }
    }
