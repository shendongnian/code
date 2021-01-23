    void Session_Start(object sender, EventArgs e)
    {
         // No code needed in Session_Start
    }
    void Session_End(object sender, EventArgs e)
    {
        if (Session["MyPacksFolder"] != null)
        {
            // Folder has been created, delete it
            // ... add code to delete folder as above
        }
    }
