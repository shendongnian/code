    public virtual bool Visible
    {
        get
        {
            return !this.flags[16] 
            && (this._parent == null || this.DesignMode || this._parent.Visible);
        }
        set
        {
            // ...
        }
    }
