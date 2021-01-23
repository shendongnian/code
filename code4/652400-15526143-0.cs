    public Guid IsServerReachable()
    {
        try
        {
            using (OrganizationServiceProxy service = GetService())
            {
                WhoAmIResponse whoAmI = service.Execute(new WhoAmIRequest()) as WhoAmIResponse;
                return whoAmI.UserId;
            }
        }
        catch { return Guid.Empty; }
    }
