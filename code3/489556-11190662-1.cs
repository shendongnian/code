    const string QUERY = "INSERT INTO contacts (first_name,last_name) VALUES" + 
                          BuildQuery(c, contacts);
    public string BuildQuery(MySQLCommand c, IEnumerable<contact> contacts)
    {
        List<string> values = new List<string>();
        string query = null;
        int i = 0;
        foreach (var contact in contacts)
        {
           i++;
           query += "(@firstName" + i + ", @lastName" + i + ")";
           c.Parameters.AddWithValue("@firstName" + i, contact.first_name);
           c.Parameters.AddWithValue("@lastName" + i, contact.last_name);
           if(i < contacts.Count) 
              query += ",";
        }
    
        return query
    }
