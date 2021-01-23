    public int messageID
    {
       get 
       { 
          int retVal = 0;
          if(ViewState["messageID"] != null)
             int32.TryParse(ViewState["messageID"].ToString()); 
          return retVal;
       }
       set { ViewState["messageID"] = value; }
    }
