    //...
    string PAState = this.txtPAState.Text; 
    string PACountry = this.txtPACountry.Text; 
    string PAZipCode = this.txtPAZipCode.Text;
    string contactIDstr = Session["ContactID"] as string;
    int contactID = 0;
    if(!String.IsNullOrEmpty(conactIDStr))
        Int32.TryParse(contactIDStr, out contactID);
    aspdotnet.BusinessLogicLayer.ContactEntry AddEntry = new ContactEntry(
        contentID,
        Title,
        FirstName,MiddleName,LastName,JobTitle,Company,
        Website,OfficePhone,HomePhone,Mobile,Fax,OEmail,PEmail,
        OAStreet,OACity,OAState,OACountry,OAZipCode,PAStreet,PACity,PAState,PACountry,PAZipCode
    ); 
