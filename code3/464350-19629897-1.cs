    // Parameters.
    Dictionary<string, string> parameters = new Dictionary<string, string>();
    parameters[SessionParameter.AtomPubUrl] = "http://yourserver:port/alfresco/cmisatom"; // Change this to yours.
    parameters[SessionParameter.BindingType] = BindingType.AtomPub;
    parameters[SessionParameter.AuthenticationProviderClass] = "DotCMIS.Binding.NtlmAuthenticationProvider";
    
    // No need for username and password, thanks to NTLM-based SSO (Single Sign On)
    //parameters[SessionParameter.User] = "<username>";
    //parameters[SessionParameter.Password] = "<password>";
    
    SessionFactory factory = SessionFactory.NewInstance();
    ISession session = factory.GetRepositories(parameters)[0].CreateSession();
    
    // List all children of the root folder.
    IFolder rootFolder = session.GetRootFolder();
    foreach (ICmisObject cmisObject in rootFolder.GetChildren())
    {
        Console.WriteLine(cmisObject.Name);
    }
