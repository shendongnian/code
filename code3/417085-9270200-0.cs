    using (SqlConnection connection = new SqlConnection("Data Source=nesoi;Initial Catalog=SalesDWH;Integrated Security=True"))
    {
        string queryString = "INSERT INTO SalesDWH.dbo.PendingSpecimens([Date Entered], [Specimen ID], Test, Agency) VALUES (" + fields[0] + ", " + fields[1] + ", " + fields[2] + ", " + fields[4] + ")";
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
