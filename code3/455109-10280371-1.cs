    public void Wait()
    {
        if(t.IsActive)//set by the .start method
        {
            if(t.isComplete)
            {
                 //do some stuff
                 t.Stop();
            }
            else
            {
                //we're still timing, nothing to do here
            }
        }
    }
