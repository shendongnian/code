    public void SavePlayer(Contact contact)
        {
            using (var context = new EfDb())
            {                
                if (contact.ContactId == 0)
                {                    
                    context.Contacts.Add(contact);
                }
                else if (contact.ContactId > 0)
                {
                    var currentContact = context.Contacts
                        .Include(c => c.PhoneNumber)
                        .Single(c => c.ContactId== contact.ContactId);
                    context.Entry(currentContact).CurrentValues.SetValues(contact);
                    currentContact.PhoneNumber= contact.PhoneNumber;
                }
                context.SaveChanges();
            }
        }
