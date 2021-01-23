        // Set the contact's IM information.
        newEntry.IMs.Add(new IMAddress()
            {
                Primary = true,
                Rel = ContactsRelationships.IsHome,
                Protocol = ContactsProtocols.IsGoogleTalk,
                **Address = "liz@gmail.com",**
            });
