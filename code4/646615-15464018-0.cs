    try
    {
        // WCF/channel accessing code here
    }
    catch (Exception ex)
    {
        String errorMessages = "";
        while (ex != null)
        {
            errorMessages += ex.Message + Environment.NewLine + Environment.NewLine;
            ex = ex.InnerException;
        }
        // errorMessages contains all of the stack error messages (including "No Yay. =(")
    }
