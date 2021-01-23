    public List<Contact> GetContacts()
            {
                DataTable dt = new DataTable();
    
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Contacts]", Connection);
                Adapter.SelectCommand = cmd;
    
                Connection.Open();
                Adapter.SelectCommand.ExecuteNonQuery();
                Adapter.Fill(dt);
                Connection.Close();
    
                var Contacts = (from row in dt.AsEnumerable()
    
                                select new Contact
                                {
                                    ContactID = row.Field<int>("ContactID"),
                                    Surname = row.Field<string>("Surname"),
                                    Forename = row.Field<string>("Forename"),
                                    MobileNumber = row.Field<string>("MobileNumber"),
                                    EmailAddress = row.Field<string>("EmailAddress"),
                                    Information = row.Field<string>("Information")
    
                                }).ToList();
    
                
    
                return Contacts;
            }
