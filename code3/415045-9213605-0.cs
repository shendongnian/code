    _list = FindViewById<ListView>(Resource.Id.contact_list);
    
    var contacts = ManagedQuery(ContactsContract.Contacts.ContentUri, null, null, null, null);
    
    _list.Adapter = 
        new SimpleCursorAdapter(
            this, 
            Resource.Layout.contacts_item, 
            contacts, 
            new string[] { ContactsContract.ContactsColumnsConsts.DisplayName }, 
            new int[] { Resource.Id.contact_name });
