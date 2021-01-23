    public static void RethrowExceptionWithFullDetailInMessage(string msg, Exception ex)
    {
        string msg = "";
        while (curEx != null)
        {
            msg += "\r\n";
            msg += cnt++ + " ex.message: " + curEx.Message + "\r\n";
            msg += "Stack: " + ex.StackTrace;
        }
    		ex.GetType().GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ex, "My New Message")
    }
