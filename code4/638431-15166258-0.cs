    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        MembershipUser User = Membership.GetUser(CreateUserWizard1.UserName);
        object userGUID = User.ProviderUserKey;
        TextBox firstname = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("FirstName");
        TextBox lastname = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("LastName");
        TextBox companyname = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("CompanyName");
        TextBox address1 = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address1");
        TextBox address2 = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address2");
        TextBox city = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("City");
        DropDownList state = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("State");
        TextBox zip = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Zip");
        TextBox phone_number = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Phone");
        TextBox email_address = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Email");
        SqlDataSource1.InsertParameters.Add("userid", userGUID.ToString());
        SqlDataSource1.InsertParameters.Add("firstname", firstname.Text);
        SqlDataSource1.InsertParameters.Add("lastname", lastname.Text);
        SqlDataSource1.InsertParameters.Add("companyname", companyname.Text);
        SqlDataSource1.InsertParameters.Add("address1", address1.Text);
        SqlDataSource1.InsertParameters.Add("address2", address2.Text);
        SqlDataSource1.InsertParameters.Add("city", city.Text);
        SqlDataSource1.InsertParameters.Add("state", state.SelectedValue);
        SqlDataSource1.InsertParameters.Add("zip", zip.Text);
        SqlDataSource1.InsertParameters.Add("phone_number", phone_number.Text);
        SqlDataSource1.InsertParameters.Add("email_address", email_address.Text);
        SqlDataSource1.Insert();
    }
