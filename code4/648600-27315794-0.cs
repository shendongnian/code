    try
    { ..}
     catch(Exception ex)
    {
        Debug.WriteLine(ex.Message);
        Debug.WriteLine(ex.StackTrace);
        Debug.WriteLine(ex.InnerException.ToString());
    }
