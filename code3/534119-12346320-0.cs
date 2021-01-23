    //Global Declaration
    public static void Message(String message, Control cntrl)
    {
      ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "alert", "alert('" + message + "');", true);
    }
    //Call any where, where you want to display message
     Message("Any message here", this);
