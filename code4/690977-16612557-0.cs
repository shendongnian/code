     DataTable table = new DataTable();
     table.Columns.Add("IDNumber", typeof(string));
     table.Columns.Add("Name", typeof(string))
     table.Columns.Add("Surname", typeof(string));
     table.Columns.Add("Company Name", typeof(string));
        while (reader.Read())
          {                    
             table.Rows.Add("@idnumber", "@name", "@surname", "@companyN");
          }
