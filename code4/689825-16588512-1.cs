    public void Execute(IServiceProvider serviceProvider)
    {
        var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        var service = ((IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory))).CreateOrganizationService(context.UserId);
        
        var originalContact = context.InputParameters["Target"] as Entity;
        var newContact = new Entity("new_historicalcontact");
        if (originalContact.Contains("firstname"))
        {
            newContact.Add("new_firstname", orginalContact["firstname"]);
        }
        if (originalContact.Contains("emailaddress1"))
        {
            newContact.Add("new_emailaddress1", orginalContact["emailaddress1"]);
        }
        if (originalContact.Contains("parentcustomerid"))
        {
            newContact.Add("new_parentcustomerid", orginalContact["parentcustomerid"]);
        }
        
        //etc etc for other properties
        service.Create(newContact);
    }
