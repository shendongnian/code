    da = new SqlDataAdapter("SELECT * FROM annotations WHERE annotation LIKE @search",
                            _mssqlCon.connection);
    da.SelectCommand.Parameters.Add(new SqlParameter
    {
        ParameterName = "@search",
        Value = "%" + txtSearch.Text + "%",
        SqlDbType = SqlDbType.NVarChar,
        Size = 2000  // Assuming a 2000 char size of the field annotation (-1 for MAX)
    });
