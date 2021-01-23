    public IEnumerable<UserRegistration> GetRegistrationsPendingAdminApproval()
    {
        var r =
            from UserRegistration ur in _Session.Query<UserRegistration>()
            where ur.Status == AccountRegistrationStatus.PendingAdminReview
            select ur;
        NHibernateUtil.Initialize(r);
        return r.ToList();
    }
