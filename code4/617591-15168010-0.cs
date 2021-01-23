    PSDKPasswordRequest objPasswordRequest;
    PSDKPassword objPassword;
    objPasswordRequest = new PSDKPasswordRequest();
    objPasswordRequest.AppID = "MyApp";
    objPasswordRequest.Safe = "MySafe";
    objPasswordRequest.Object = "MyAccount";
    
    objPassword = PasswordSDK.GetPassword(objPasswordRequest);
    password = objPassword.Content;
    username = objPassword.UserName;
