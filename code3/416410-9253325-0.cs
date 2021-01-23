    Mapper.CreateMap<Contact, SpecialContact>();
    Contact contact = new Contact();
    contact.ContactID = 123;
    contact.Name = "Jeff";
    SpecialContact specialContact = Mapper.Map<Contact, SpecialContact>(contact);
