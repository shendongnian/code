    public static void MyMethod(SqlString myMessage)
    {
        if (! myMessage.IsNull) 
        {
            String myMessageString = myMessage.ToString();
            // Do stuff
        }
    }
