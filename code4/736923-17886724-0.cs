    SforceService SfdcBinding = null;
    LoginResult CurrentLoginResult = null;
    SfdcBinding = new SforceService();
    try 
    {
       CurrentLoginResult = SfdcBinding.login(userName, password);
    }
    catch (System.Web.Services.Protocols.SoapException e) 
    {
       // This is likely to be caused by bad username or password
       SfdcBinding = null;
       throw (e);
    }
    catch (Exception e) 
    {
       // This is something else, probably communication
       SfdcBinding = null;
       throw (e);
    }
