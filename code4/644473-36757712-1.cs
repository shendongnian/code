            OracleDataAdapter da = new OracleDataAdapter(cmd);
            try
            {
                con.Open();
                da.UpdateCommand = cmd;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return Convert.ToInt32(cmd.Parameters["PV_NUM_EMPLOYEES_O"].Value);
        }
