    var setCorrectUrl = new Dictionary<int, Action<Contact>>
    {
        // Appropriate entries in here, e.g. (syntax not quite right)
        {
            1,
            (contact) => FacebookIcon.NavigateUrl = contact.ContactURL;
        }
    }
    
    foreach (var con in contacts)
    {
        setCorrectUrl[con.ContactTypeID](con);
    }
