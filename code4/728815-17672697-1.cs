     public bool IsNull(Person person)
        {
            if(Person != null && Person.Contact!=null && Person.Contact.Address!= null && Person.Contact.Address.City != null)
                return false;
            return true;
        }
