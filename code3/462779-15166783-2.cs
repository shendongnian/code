    public static void SessionIsAlive(HttpSessionStateBase Session)
    {
        if (Session.Contents.Count == 0)
        {
            Response.Redirect("Timeout.html"); 
        }
        else
        {
            InitializeControls();
        }
    }
