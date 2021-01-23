    public Child()
    {
        try
        {
            Debug.WriteLine("Child()");
            throw new Exception();
        }
        fault
        {
            base.Dispose(true);
        }
    }
