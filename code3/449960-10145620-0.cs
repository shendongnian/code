    UserData = pModel.PartyId.ToString() + "|" + pModel.BusinessName + "|" + pModel.FirstName + "|" + pModel.LastName + "|" + pModel.ImageUrl + "|" + UsersRole + "|" + IsAct;//PID, BusName, FirstName, LastName, imgUrl, Role, IsAct
    // Create the cookie that contains the forms authentication ticket
    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(UN, true);
    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, UserData);
    authCookie.Value = FormsAuthentication.Encrypt(newTicket);
    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
 
