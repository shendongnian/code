    Public List<Contact> GetContacts()
    {
    	List<Contact> contactList = new List<Contact>();
    
    	con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Information", con);
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
    
            dta.Fill(dt);
            con.Close();
    
    
    	for (int index = 0; index < dt.Rows.Count; index++)
    	{
    		Contact newContact = new Contact();
    
    		newContact.ID = dt.Rows[index]["CONTACT_ID"];
    		newContact.Name = dt.Rows[index]["CONTACT_NAME"];
    		newContact.Address = dt.Rows[index]["CONTACT_ADDRESS"];
    		newContact.NO = dt.Rows[index]["CONTACT_NO"];
    
    		contactList.Add(newContact);
    	}
    
    	return contactList;
    }
