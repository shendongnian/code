    string service = "MyService";
    string method = "SaveBusinessUserInfo";
    Type userMasterType = invoker.AvailableTypes["FullNamespace.UserMaster"];
    Type userEmailType = invoker.AvailableTypes["FullNamespace.UserEmail"];
    object userMaster = Activator.CreateInstance(userMasterType);
    object userEmail = Activator.CreateInstance(userEmailType);
    // now that you have obtained the 2 instances you could set properties on them:
    userMasterType.GetProperty("Username").SetValue(userMaster, "some username", null);
    ...
     
    object[] args = new object[] { userMaster, userEmail, "foo bar" };
     
    long result = invoker.InvokeMethod<long>(service, method, args);
