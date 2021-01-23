    using(SqlConnection connection = new SqlConnection(@"workstation id = PC-PC; user id=sa;Password=sapassword; data source=pc-pc; persist security info=True;initial catalog=CleanPayrollTest2"))
    {
        using(SqlCommand command = new SqlCommand(sql, connection))
        {
            try
            {
                connection.Open();  
                for (int i =0; i< gridView3.RowCount; i++)
                {
                    SqlParameter parameter = new SqlParameter();
                    // TODO: handle name accordingly (MName, LName etc.)
                    parameter.ParameterName = "@FName";
                    // TODO: handle type accordingly
                    parameter.SqlDbType = SqlDbType.NVarChar; 
                    parameter.Direction = ParameterDirection.Input;
                    // TODO: use the field name accordingly
                    parameter.Value = Convert.ToString(gridView3.GetRowCellValue(i, "FieldName"));
                }
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                // TODO: handle the exception
            }
        }
    }
