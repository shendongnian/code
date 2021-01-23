    protected void Page_Load(object sender, EventArgs e)
    {
        List<MembershipUserCollection> usernamelist = new List<MembershipUserCollection>();
        usernamelist.Add(Membership.GetAllUsers());
        List<ProfileCommon> myProfileList = new List<ProfileCommon>();
            foreach (MembershipUser user in usernamelist[0])
            {
                string username = user.ToString();
                myProfileList.Add(Profile.GetProfile(username));
                Label emailLabel = profilelist.FindControl("EmailLabel") as Label;
            }
    }
