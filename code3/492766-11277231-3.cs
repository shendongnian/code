    DataTable tblEmail = new DataTable();
    using (var con = new MySqlConnection(Properties.Settings.Default.MySQL))
    using (var da = new MySqlDataAdapter("SELECT Email, Name FROM Email WHERE id=@id", con))
    {
        da.SelectCommand.Parameters.AddWithValue("@id", ID);
        da.Fill(tblEmail);
    }
    DataRow row = tblEmail.AsEnumerable().Single();
    String email = row.Field<String>("Email");
    String name  = row.Field<String>("Name");
