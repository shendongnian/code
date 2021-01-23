    string status;
    public static string Status 
    {
        get 
        { 
           return status; 
        }
        set 
        {
            status = value;
            Refresh();
        } 
    }
    private static void Refresh()  // Change signature of function
    {
        lblStatus.Text = Status.ToString();
    }
