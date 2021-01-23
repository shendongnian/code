    [WebMethod]
    public static OfficeDetails[] BindSearchDatatable(string officename)
    {
        using (var con = new SqlConnection(@"Data Source=GTL--7\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
        using (var cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "SELECT OfficeName, City, Country FROM Office WHERE OfficeName LIKE @officename";
            cmd.Parameters.AddWithValue("@officename", "%" + officename + "%");
            using (var reader = cmd.ExecuteReader())
            {
                var details = new List<OfficeDetails>();
                while (reader.Read())
                {
                    var office = new OfficeDetails();
                    office.OfficeName = reader.GetString(reader.GetOrdinal("OfficeName"));
                    office.City = reader.GetString(reader.GetOrdinal("City"));
                    office.Country = reader.GetString(reader.GetOrdinal("Country"));
                    details.Add(office);
                }
                return details.ToArray();
            }
        }
    }
