    protected void RegisterUserWizard_CreatedUser(object sender, EventArgs e)
    {
        try
        {
            // Try to update the customer table with the additional information
            using (OrderEntities entities = new OrderEntities())
            {
                // Read in all the values from the form
                TextBox custTitle = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerTitle");
                TextBox custName = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerName");
                TextBox custSurname = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerSurname");
                TextBox custAddress1 = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerAddressLine1");
                TextBox custAddress2 = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerAddressLine2");
                TextBox custAddress3 = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerAddressLine3");
                TextBox custCity = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerCity");
                TextBox custCounty = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerCounty");
                TextBox custPostcode = (TextBox)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerPostcode");
                DropDownList custCountry = (DropDownList)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomerCountry");
    
                Customer custInfo = entities.Customers.Where(c => c.UserName == RegisterUserWizard.UserName).FirstOrDefault();
    
                if (custInfo != null)
                {
                    custInfo.Email = RegisterUserWizard.Email;
                    custInfo.Password = RegisterUserWizard.Password;
                    custInfo.Title = custTitle.Text;
                    custInfo.Firstname = custName.Text;
                    custInfo.Surname = custSurname.Text;
                    custInfo.AddressLine1 = custAddress1.Text;
                    custInfo.AddressLine2 = custAddress2.Text;
                    custInfo.AddressLine3 = custAddress3.Text;
                    custInfo.City = custCity.Text;
                    custInfo.County = custCounty.Text;
                    custInfo.Postcode = custPostcode.Text;
                    custInfo.CountryID = custCountry.SelectedValue;
                    custInfo.CreatedDate = DateTime.Now;
    
                    entities.SaveChanges();
    
                    FormsAuthentication.SetAuthCookie(RegisterUserWizard.UserName, false);
    
                    // Redirect user back to calling page
                    string continueUrl = RegisterUserWizard.ContinueDestinationPageUrl;
                    if (String.IsNullOrEmpty(continueUrl))
                    {
                        continueUrl = "~/";
                    }
                    Response.Redirect(continueUrl);
    
                }
                else
                {
                    // Throw an Exception so that we redisplay CreateUserWizard showing error message
                    throw new Exception("An error occurred updating account details, please try again");
                }
            }
        }
        catch (Exception ex)
        {
            // Delete the incomplete user from the membership to avoid duplicate UserName errors if the user tries again
            Membership.DeleteUser(RegisterUserWizard.UserName); 
            // Store the error message in the Context and transfer back to the page preserving the form
            Context.Items.Add("ErrorMessage", ex.Message);
            Server.Transfer(Request.Url.PathAndQuery, true);
        }
    }
