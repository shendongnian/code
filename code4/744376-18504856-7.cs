    public AuthHeader Authentication;
    [SoapHeader ("Authentication", Required=true)]
    [WebMethod (Description="WebMethod authentication testing")]
    public string SensitiveData()
    {
            
    //Do our authentication
    //this can be via a database or whatever
    if(Authentication.Username == "userName" && 
                Authentication.Password == "pwd")
    {
       //Do your thing
       return "";
    
    }
    else{
       //if authentication fails
       return null;
     }            
    }
