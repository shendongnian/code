            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["OracleBD"].ConnectionString);
            OleDbCommand cmd = new OleDbCommand("Z_TESTE_IN_FUNC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@procValueName", "myValue");
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            try
            {
                da.Fill(dt);
            }
            catch (Exception excp)
            {
                //Handle Exception
            }
            finally
            {
                conn.Close();
            }
