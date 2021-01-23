    if (Request.QueryString["pid"] != null)
    {
        int pid;
        if (int.TryParse(Request.QueryString["pid"].ToString(), out pid))
        {
            //Then its OK and you have an 
            //integer, put the codes here
        }
        else
        { 
            //The query string has value
            //but the value is not valid
            //(not an integer value)
        }
    }
