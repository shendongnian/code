        string nextChunkId;
        IList<Contact> list = Utility.SearchContactByEmail(AuthenticationData, emailAddress, out nextChunkId);
        if (list.Count == 0)
        {
            // create new Contact
            Contact contact = GetContactInformation();
            Utility.CreateNewContact(AuthenticationData, contact);
            Response.Redirect("~/AddContactConfirmation.aspx");
        }
        else
        {
            throw new ConstantException(String.Format(CultureInfo.CurrentCulture,
                "Email address \"{0}\" is already a contact", txtEmail.Text.Trim()));
        }
