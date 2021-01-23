    private AutoResetEvent are = new AutoResetEvent();
    
    public void setOutput(int value)
    {
        // Do not wait (block) == wait 0ms
        if(are.WaitOne(0))
        {
            try
            {
                // Put your code here
            }
            finally
            {
                are.Set()
            }
        }
    }
