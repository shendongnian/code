    internal virtual bool GetVisibleCore()
    {
        if (!this.GetState(0x2))
        {
            return false;
        }
        return ((this.ParentInternal == null) || this.ParentInternal.GetVisibleCore());
    }
