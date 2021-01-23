    public IList<Contact> GetContactFromDB(int pagenumber)
     {
          return context.Contacts.OrderBy(p=>p).Skip(pagenumber*10).Take(10).ToList();
     }
    
