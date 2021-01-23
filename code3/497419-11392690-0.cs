    NameValueCollection nvc = Request.Form;
    string firstname, lastname;
    if (!string.IsNullOrEmpty(nvc["txtFirstName"]))
    {
      firstname = nvc["txtFirstName"];
    }
    
    if (!string.IsNullOrEmpty(nvc["txtLastName"]))
    {
      lastname = nvc["txtLastName"];
    }
