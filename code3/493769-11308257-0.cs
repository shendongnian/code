    if (!User.Identity.IsAuthenticated)
    {
        Login memberLogin = (Login)this.MemberValidation.FindControl("MemberLogin");
        Literal informationMessage = (Literal)memberLogin.FindControl("InformationMessage");
        informationMessage.Text = "Hello World";
    }
