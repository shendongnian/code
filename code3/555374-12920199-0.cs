    for (int i = 0, i < Request.form["HiddenFieldHere"], i++)
    {
            Contacts contact = new Contacts(); 
            contact.CustomerID  = i; 
            contact.ContactDetail=  Request.Form[string.format("contact{0},i)].ToString(); 
    }
