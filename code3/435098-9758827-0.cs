       public List<Name> GetNames() 
       { 
     
            List<Name> names = new List<Name>(); 
     
            using (SqlCommand objcmd = new SqlCommand("Select * from Names", sql)) 
            { 
                SqlDataReader reader = objcmd.ExecuteReader(); 
                while (reader.Read()) 
                { 
                    Name name = new Name();
                    name.NameID = reader.GetInt32(0); 
                    name.Name = reader["Name"].ToString(); 
                    names.Add(name);
                } 
            } 
            return names; 
        } 
    
