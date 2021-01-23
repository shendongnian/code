    string UserName;
    string EmailAddress;
    string FirstName;
    ....
    if (UserContext != null && UserContext.Account != null)
            {
    
                if (UserContext.UserName != null)
                { UserName = string.Format(UserContext.UserName); }
    
                if (UserContext.EmailAddress != null)
                { EmailAddress = string.Format(UserContext.EmailAddress); }
    
                if (UserContext.Account.PrimaryContactFirstName != null)
                { FirstName = string.Format(UserContext.Account.PrimaryContactFirstName); }
    
                if (UserContext.Account.PrimaryContactLastName != null)
                { LastName = string.Format(UserContext.Account.PrimaryContactLastName); }
    
                if (UserContext.Account.PrimaryContactPhoneNumber != null)
                { PhoneNumber = string.Format(UserContext.Account.PrimaryContactPhoneNumber); }
    
                if (UserContext.Account.HeadquartersAddressLine1 != null)
                {
                    AddressLine1 = string.Format(UserContext.Account.HeadquartersAddressLine1);
    
                    if (UserContext.Account.HeadquartersAddressLine2 != null)
                    { AddressLine2 = string.Format(UserContext.Account.HeadquartersAddressLine2); }
                }
    
                if (UserContext.Account.HeadquartersCity != null)
                { City = string.Format(UserContext.Account.HeadquartersCity); }
    
                if (UserContext.Account.HeadquartersState != null)
                { State = string.Format(UserContext.Account.HeadquartersState); }
    
                if (UserContext.Account.HeadquartersZip != null)
                { ZipCode = string.Format(UserContext.Account.HeadquartersZip); }
    
                if (UserContext.Account.Name != null)
                { Name = string.Format(UserContext.Account.Name); }
    
                string body = string.Format(Resources.ContactUsLoggedInEmailTemplate, model.FirstName, model.LastName, model.PhoneNumber, model.Email, model.ReasonForContact, model.Message, UserName, EmailAddress, FirstName, LastName, PhoneNumber, AddressLine1, AddressLine2, City, State, ZipCode, Name);
    
                string subject = string.Format("Web Submit: {0}", model.ReasonForContact);
    
                EmailHelper.SendEmail("support@website.com", subject, body, true);
    
            }
            if (UserContext == null)
            {
                body = string.Format(Resources.ContactUsEmailTemplate, model.FirstName, model.LastName, model.PhoneNumber, model.Email, model.ReasonForContact, model.Message);
    
                subject = string.Format("Web Submit: {0}", model.ReasonForContact);
    
                EmailHelper.SendEmail("support@website.com", subject, body, true);
            }
    
            return RedirectToAction("ContactConfirmation");
