    protected override void OnInit(EventArgs e)
    {
      if (Request.Params["post"] == "true")
      {
        submitValues(Request.Params["email"]);
      }
    }
    
    public void submitValues(string email)
    {
     string returnValue = string.Empty;
     //Call DB and send response back
    
     Response.Write("{\"result\":\"" + retrunValue+ "\"}");
     Response.End();
    }
     
 
