    public int messageID
    {
       get 
       { 
          int retVal = 0;
          if(ViewState["messageID"] != null)
             Int32.TryParse(ViewState["messageID"].ToString(), out retVal); 
          return retVal;
       }
       set { ViewState["messageID"] = value; }
    }
