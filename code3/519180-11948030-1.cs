    public static void ShowMessage(System.Web.UI.Page Pointer, string Message)
    {
        if (!Pointer.ClientScript.IsStartupScriptRegistered("message"))
          ScriptManager.RegisterStartupScript(Pointer,
                                              Pointer.Master.GetType(),
                                              "message", 
                                              "ShowMessage('" + Message + "');", 
                                              true);
    }
