    using(SqlConnection varConnection = new SqlConnection(Locale.sqlDataConnectionDetails)) {
        using (var sqlWrite = new SqlCommand(preparedCommand, varConnection)) {
            sqlWrite.Parameters.AddWithValue("@varSecus_agr_fname", varSecus_agr_fname == "" ? (object) DBNull.Value : varSecus_agr_fname);
            varConnection.Open();
            sqlWrite.ExecuteNonQuery();
        }
    }
