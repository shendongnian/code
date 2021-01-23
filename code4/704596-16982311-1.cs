    foreach (MyFileHelpersSpec result in results)
    {
        Customer customer = new Customer();
        customer.Name = result.Name;
        if (!String.IsNullOrWhiteSpace(Phn1) 
            || !String.IsNullOrWhiteSpace(Email1))
        {
            Contact contact = new Contact();
            contact.Phone = result.Phn1;
            contact.Email = result.Email1;
            customer.Contacts.Add(contact);
        }
        if (!String.IsNullOrWhiteSpace(Phn2)
            || !String.IsNullOrWhiteSpace(Email2))
        {
            Contact contact = new Contact();
            contact.Phone = result.Phn2;
            contact.Email = result.Email2;
            customer.Contacts.Add(contact);
        }               
    }
