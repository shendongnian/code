    public void AddToROT()
    {
        IRunningObjectTable rot = null;
        IMoniker moniker = null;
        try
        {
            // Get the ROT
            rot = GetRunningObjectTable(0);
            // Create a moniker for the graph
            moniker = CreateItemMoniker("!", "{" + CLASS_ID  + "}");
            // Registers the graph in the running object table
            cookie = rot.Register(ROTFLAGS_REGISTRATIONKEEPSALIVE, this, moniker);
        }
        finally
        {
            if (null != moniker) Marshal.FinalReleaseComObject(moniker);
            if (null != rot) Marshal.FinalReleaseComObject(rot);
        }
    }
