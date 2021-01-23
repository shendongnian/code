    public ResumeViewModel ProfileGetInfoForCurrentUser()
    {
        var user = Membership.GetUser();
        ProfileBase profile = ProfileBase.Create(user.UserName);
        ResumeViewModel resume = new ResumeViewModel();
        resume.Email = user.Email;
        resume.FullName = user.UserName;
        return resume;
    }
