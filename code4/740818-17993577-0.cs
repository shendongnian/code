    private bool ShowSizingGrip
    {
        get
        {
            if (this.SizingGrip && base.IsHandleCreated)
            {
                if (base.DesignMode)
                {
                    return true;
                }
                HandleRef rootHWnd = WindowsFormsUtils.GetRootHWnd(this);
                if (rootHWnd.Handle != IntPtr.Zero)
                {
                    return !UnsafeNativeMethods.IsZoomed(rootHWnd);
                }
            }
            return false;
        }
    }
