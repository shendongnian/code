    using (TransactionScope tScope = new TransactionScope())
    {
        MembershipCreateStatus createStatus;
        Membership.CreateUser(model.Email, model.Password, model.Email, null, null, true, model.Id, out createStatus);
        if (createStatus == MembershipCreateStatus.Success)
        {
           Roles.AddUserToRole(model.Email, "Administrator");
           _UpdatePersonnelAccess(model);
           _UpdatePersonnelHasAccess(model);
           _SendEmail_Welcome(model);
           PersonSessionLog.ManageSession(model);
        }
        else
           ViewBag.Message = "Error";
        
        tScope.Complete();
    }
