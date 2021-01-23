    const string authenticationPrefix = "system.webServer/security/authentication/";
    private Dictionary<string, string> authenticationDescriptions = new Dictionary<string,string>()
    { 
        {"anonymousAuthentication", "Anonymous Authentication"},
        {"windowsAuthentication", "Windows Authentication"},
    };
    Configuration configuration = application.GetWebConfiguration();
    IEnumerable<string> authentications = ((String)configuration.GetMetadata("availableSections")).Split(',').Where(
        authentication => authentication.StartsWith(authenticationPrefix));
               
    foreach (string authentication in authentications)
    {
        string authName = authentication.Substring(authenticationPrefix.Length);
        string authDesc;
        authenticationDescriptions.TryGetValue(authName, out authDesc);
        if(String.IsNullOrEmpty(authDesc))
            continue;
        authenticationCheckedListBox.Items.Add(authDesc, (bool)configuration.GetSection(authentication).GetAttributeValue("enabled"));
    }
