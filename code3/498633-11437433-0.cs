    public void AddUserToOrganization(Guid UserId, int OrganizationId)
    {
        // Get the user and the organization that you want to join
        var user = _data.Users.First(x => x.UserId == UserId);
        var org = _data.Organizations.First(x => x.OrganizationID == OrganizationId);
        // Add the organization to the user
        user.Organizations.Add(org);
        // Save
        context.SaveChanges();
    }
