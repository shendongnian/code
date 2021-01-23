    public function GetPackages() as List<Package>
    {
     using (var connection = my_DB.GetConnection())
        {
            try
            {
                connection.Open();
                SqlDataReader rdr = null;
                dt = new DataTable();
                string CommandText = "SELECT ID, Name FROM TABLENAME WHERE UPPER(Import_File_Source) LIKE '%abc%' and STATUS = 1";
        
                SqlCommand cmd = new System.Data.SqlClient.SqlCommand(CommandText, connection);
        
                 var packages = new List<Package>();
                 using(var reader = cmd.ExecuteReader())
                 {
                 do while(reader.Read())
                   {
                   packages.Add(new Package({ID = reader.GetString(0), Name = reader.GetString(1)})
                   }
                 }
                
                cbPackages.DataSource = packages;
                cbPackages.ValueMember = "ID";
                cbPackages.DisplayMember = "Name";
                return packages;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
                return new List<Package>();
            }
            connection.Close();
        }
