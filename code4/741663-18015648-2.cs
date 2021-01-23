    using (var connection = my_DB.GetConnection())
    {
        try
        {
            connection.Open();
            SqlDataReader rdr = null;
            dt = new DataTable();
            string CommandText = "SELECT ID, Name FROM TABLENAME WHERE UPPER(Import_File_Source) LIKE '%abc%' and STATUS = 1";
    
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(CommandText, connection);
    
             packages = new List<Package>();
             using(var reader = cmd.ExecuteReader())
             {
             Do While(reader.Read())
               {
               packages.Add(new Package({ID = reader.GetString(0), Name = reader.GetString(1)})
               }
             }
            
            cbPackages.DataSource = packages;
            cbPackages.ValueMember = "ID";
            cbPackages.DisplayMember = "Name";
    
        }
        catch (Exception E)
        {
            MessageBox.Show(E.Message.ToString());
        }
        connection.Close();
    }
