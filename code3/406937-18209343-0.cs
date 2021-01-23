    public static void Alert(string message,Page page)
    {
           ScriptManager.RegisterStartupScript(page, page.GetType(),
          "err_msg",
          "alert('" + message + "');",
          true);
    }
