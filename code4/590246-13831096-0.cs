    bool contactExists = _db.Contacts.Any(contact => contact.ContactName.Equals(ContactName));
    if (contactExists)
    {
        return -1;
    }
    else
    {
        _db.Contacts.Add(myContact);
        _db.SaveChanges();
        return myContact.ContactID;
    }
