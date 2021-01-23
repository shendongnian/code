    private void ExecuteSecure(Action a)
    {
        try
        {
            if (InvokeRequired)
            {
                lock (o)
                {
                    Invoke(a);
                }
            }
            else
                a();
        }
        catch (Exception) //again **sigh** this does not catch the error
        { }
