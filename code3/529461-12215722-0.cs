       protected void Page_Load(object sender, EventArgs e)
       {
        String cbReference =Page.ClientScript.GetCallbackEventReference(this,
            "arg", "ReceiveServerData", "context");
        String callbackScript;
        callbackScript = "function CallServer(arg, context)" +
            "{ " + cbReference + ";}";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            "CallServer", callbackScript, true);
       }
     System.IO.StringWriter strDataGridHtml= new System.IO.StringWriter(); 
     public void RaiseCallbackEvent(String eventArgument)
        {
             string idToBeDeleted=eventArgument;
             //Write deleteCode
             //DataBind the Grid
             HtmlTextWriter htwObject = new HtmlTextWriter(strDataGridHtml);
             GridViewControl.RenderControl(htwObject);
        }        
    public String GetCallbackResult()
        {
            return strDataGridHtml.ToString();
        }
