    bool isBusy = false;
    public static void Foo()
    {
        if (!isBusy)
        {
            isBusy = true;
            try
            {            
                //do the job
            }
            finally
            {
                isBusy = false;
            }
        }
    }
