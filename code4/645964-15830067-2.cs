    protected void Page_Load(object sender, EventArgs e)
    {
        OpenIdAjaxRelyingParty rp = new OpenIdAjaxRelyingParty();
        var response = rp.GetResponse();
        if (response != null)
        {
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    NotLoggedIn.Visible = false;
                    Session["GoogleIdentifier"] = response.ClaimedIdentifier.ToString();
                    var fetchResponse = response.GetExtension<FetchResponse>();
                    Session["FetchResponse"] = fetchResponse;
                    var response2 = Session["FetchResponse"] as FetchResponse;
                       
                    string UserName = response2.GetAttributeValue(WellKnownAttributes.Name.First) ?? "Guest"; // with the OpenID Claimed Identifier as their username.
                    string UserEmail = response2.GetAttributeValue(WellKnownAttributes.Contact.Email) ?? "Guest";   
                    Response.Redirect("Default2.aspx");
                    break;
                case AuthenticationStatus.Canceled:
                    lblAlertMsg.Text = "Cancelled.";
                    break;
            }
        }
    }
    protected void OpenLogin_Click(object sender, CommandEventArgs e)
    {
        
        string discoveryUri = e.CommandArgument.ToString();
        OpenIdRelyingParty openid = new OpenIdRelyingParty();
        var url = new UriBuilder(Request.Url) { Query = "" };
        var request = openid.CreateRequest(discoveryUri); // This is where you would add any OpenID extensions you wanted
        var fetchRequest = new FetchRequest(); // to fetch additional data fields from the OpenID Provider
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
        request.AddExtension(fetchRequest);
        request.RedirectToProvider();
    }
