            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["OracleBD"].ConnectionString);
            OleDbCommand cmd = new OleDbCommand("Z_TESTE_IN_FUNC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@procValueName", "myValue");
            conn.Open();
            try
            {
                object o = cmd.ExecuteScalar();
                //cast o to something you want
            }
            catch (Exception excp)
            {
                //Handle Exception
            }
            finally
            {
                conn.Close();
            }
