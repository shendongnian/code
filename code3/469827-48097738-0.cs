    private void TryToAttach(IntPtr ownerHandle)
    {
        if(ownerHandle == IntPtr.Zero)
        {
            return;
        }
        try
        {
            var helper = new WindowInteropHelper(window) { Owner = ownerHandle };
        }
        catch(Exception e)
        {
            Logger.Error(e, "Could not attach window.");
        }
    }
