    localhost.Service objWebService = newlocalhost.Service();
    localhost.AuthSoapHd objAuthSoapHeader = newlocalhost.AuthSoapHd();
    string strUsrName =ConfigurationManager.AppSettings["UserName"];
    string strPassword =ConfigurationManager.AppSettings["Password"];
 
    objAuthSoapHeader.strUserName = strUsrName;
    objAuthSoapHeader.strPassword = strPassword;
 
    objWebService.AuthSoapHdValue =objAuthSoapHeader;
    string str = objWebService.HelloWorld();
 
    Response.Write(str);
