    public string UserNameInSession 
    {
    	get 
               { 
                  return HttpContextCurrent["UserNameSessionKey"].ToString();
               }
    	set 
               { 
                  HttpContextCurrent["UserNameSessionKey"] = value; 
               }
    }
