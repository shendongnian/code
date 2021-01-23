    foreach (SPService service in SPFarm.Local.Services)
    {
        if (service.Name.Equals("ServiceName"))
        {
            foreach (SPServiceApplication serviceApp in service.Applications)
            {
                //This gets the service app administrators
                SPCentralAdministrationSecurity serviceAppSecurity = serviceApp.GetAdministrationAccessControl();
                SPAcl<SPCentralAdministrationRights> adminAcl = serviceAppSecurity.ToAcl();
                foreach (SPAce<SPCentralAdministrationRights> rights in adminAcl)
                {
                    //Handle users
                }
                //This gets the users that can invoke the service app
                SPIisWebServiceApplication webServiceApp = (SPIisWebServiceApplication) app;
                SPIisWebServiceApplicationSecurity webServiceAppSecurity = webServiceApp.GetAccessControl();
                SPAcl<SPIisWebServiceApplicationRights> invokerAcl = webServiceAppSecurity.ToAcl();
                foreach (SPAce<SPIisWebServiceApplicationRights> rights in invokerAcl)
                {
                    //Handle users
                }
            }
        }
    }
