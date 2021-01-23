    private Int32 CallStoredProcedure(Int32 FindId)
    {
        using (var dt = new DataTable())
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var sqlCmd = new SqlCommand("SEL_StoredProcedure", conn))
                {
                    using (var sda = new SqlDataAdapter(sqlCmd))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@FindId", FindId);
                        sqlCmd.Connection.Open();
    
                        sda.Fill(dt);
                    }
                }
            }
    
            if (dt.Rows.Count == 1)
                return Convert.ToInt32(dt.Rows[0]["ID"]);
            else if (dt.Rows.Count > 1)
                throw new Exception("Multiple records were found with supplied ID; ID = " + studentId.ToString());
        }
        return 0;
    }
