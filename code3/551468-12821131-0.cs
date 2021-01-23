    List<Contact> Get_Contacts_By_Company_ID(string company_id)
    {
          List<Contact> contacts = new List<Contact>();
          var table = contacts_da.Get_Contacts_By_Company_ID(company_id);
          if(table == null)
          {
             return contacts;
          }
    
          foreach (DataRow contacts_row in contacts_da.Get_Contacts_By_Company_ID(company_id).Rows)
          {
           ....
          }
    }
