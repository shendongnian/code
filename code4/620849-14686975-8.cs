    if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
    {
        var user = userRepository.Users.Where(u => u.Email == viewModel.Email).First();
        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
        serializeModel.UserId = user.Id;
        serializeModel.FirstName = user.FirstName;
        serializeModel.LastName = user.LastName;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string userData = serializer.Serialize(serializeModel);
        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                 1,
                 viewModel.Email,
                 DateTime.Now,
                 DateTime.Now.AddMinutes(15),
                 false,
                 userData);
        string encTicket = FormsAuthentication.Encrypt(authTicket);
        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
        Response.Cookies.Add(faCookie);
        return RedirectToAction("Index", "Home");
    }
