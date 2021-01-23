    private Solutions.Models.Contact GetCustomerInfo(int itemid)
    {
         return (from c in context.Contacts.Include("Catagory") 
                 where c.ContactID == itemid
                 select c).FirstOrDefault();
    }
