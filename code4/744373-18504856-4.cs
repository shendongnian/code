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
        //they are allowed access to our sensitive data
       
       
       return "";
    
    }
    else{
       return null;
     }            
    }
