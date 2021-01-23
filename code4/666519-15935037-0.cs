        while (reader.Read())
        {
            ListA listMember = new ListA();
            listMember.ID = (int)reader["ID"];
            listMember.Name = reader["FullName"].ToString().Trim();
            
            // you have to add this line:
            listOfRecords.Add(listMember);
        }
