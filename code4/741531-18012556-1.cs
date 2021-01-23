    using (var conection = new SqlConnection("conString"))
    {
        using (var command = new SqlCommand())
        {
            command.Connection = conection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "dbo.p_InsertTenderInfo_byTenderNumber";
            command.Parameters.Add(new SqlParameter("@TenderNumber", "AA01012013"));
            conection.Open();
            command.ExecuteNonQuery();
            conection.Close();
        }
    }
