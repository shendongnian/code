    public void MessageBox(this Page Page, String Message) {
       Page.ClientScript.RegisterStartupScript(
          Page.GetType(),
          "MessageBox",
          "<script language='javascript'>alert('" + Message + "');</script>"
       );
    }
    
