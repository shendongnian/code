    foreach (Friend parseUser in parseUsers) // could be many thousands
	{
	   	var filterContacts = Contacts.Where(contact =>
                                  contact.EmailAddresses.Contains(parseUser.Email));
	   	if (filterContact.Any())
	   	{
	   		parseUser.AddContacts(filterContacts);
	   		verifiedUsers.Add(parseUser);
	   	}
	}
