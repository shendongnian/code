    foreach (Contact contact in Contacts) // phone contacts, around 500-1000
    {
        HashSet<string> emails = new HashSet<string>(
            contact.EmailAddresses.Select(e => e.EmailAddress));
        foreach (Friend parseUser in parseUsers) // could be many thousands
        {
            if(emails.Contains(parseUser.Email))
            {
                parseUser.AddContact(contact); // function call
                verifiedUsers.Add(parseUser); // add to my new aggregated list
            }
        }
    }
