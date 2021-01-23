                    var com = new SqlConnection(DC.ConnectionString).CreateCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = @"usp_StoredProcedure_1";
                    com.Parameters.Add("@aPara_Name", SqlDbType.VarChar, 20).Value = aPara_Value;
                    var table = new DataTable();
                    new SqlDataAdapter(com).Fill(table);
                    Listbox1.DataSource = table;
