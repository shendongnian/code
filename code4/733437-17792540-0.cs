    foreach (DataRow drRow in ds1.Tables[0].Rows)
    {
        comma.Parameters.Add(new OracleParameter(":ID", drRow["IDColumnFromAccessDB"]));
        comma.Parameters.Add(new OracleParameter(":DATA", drRow["DATAColumnFromAccessDB"]));
        comma.ExecuteNonQuery();
    }
