        ManagementClass userClass = new ManagementClass("root\\VisualSVN", "VisualSVN_WindowsAccount", null);                            
        ManagementClass authzClass = new ManagementClass("root\\VisualSVN", "VisualSVN_SecurityDescriptor", null);
        ManagementClass permClass = new ManagementClass("root\\VisualSVN", "VisualSVN_PermissionEntry", null);
        ManagementObject userObject = userClass.CreateInstance();
        userObject.SetPropertyValue("SID", "S-1-5-32-545");
        ManagementObject permObject = permClass.CreateInstance();
        permObject.SetPropertyValue("Account", userObject);
        permObject.SetPropertyValue("AccessLevel", 2);
        ManagementObject repo = new ManagementObject("VisualSVN_Repository.Name='Test'");
        ManagementBaseObject inParams =
            authzClass.GetMethodParameters("SetSecurity");
        inParams["Object"] = repo;
        inParams["Permissions"] = new object[] { permObject };
        ManagementBaseObject outParams =
            authzClass.InvokeMethod("SetSecurity", inParams, null);
