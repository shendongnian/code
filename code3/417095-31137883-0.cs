    try
    {
        //assume ThreadAbortException occurs here
    }
    catch (Exception ex)
    {
        if (ex.GetType().IsAssignableFrom(typeof(System.Threading.ThreadAbortException)))
        {
             //what you want to do when ThreadAbortException occurs         
        }
        else
        {
             //do when other exceptions occur
        }
    }
