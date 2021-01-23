    var contacts = db.Contacts
        .Where(cont.Accounts_CustomerID == accountId)
        .Select(cont => new ContactLight
                        {
                            AccountId = cont.Accounts_CustomerID,
                            FirstName = cont.Firstname,
                            LastName = cont.Lastname,
                            EmailAddress = cont.EmailAddress
                        })
        .AsEnumerable() //this forces request to client side
        .Where(e => ValidEmail(e.EmailAddress));
