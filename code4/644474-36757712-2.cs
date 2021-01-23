    [DataObject(true)]
        public class EmployeeDAL
        {
            [DataObjectMethod(DataObjectMethodType.Update, true)]
            public int UpdateEmployeeSalary(int percentage, int deptid, int posid)
            {
                OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                OracleCommand cmd = new OracleCommand("GIVE_RAISE_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PV_PERCENTAGE_RAISE_I", OracleType.Int32).Value = percentage;
                cmd.Parameters.AddWithValue("PV_POSITIONID_I", OracleType.Int32).Value = posid;
    stac            cmd.Parameters.AddWithValue("PV_DEPTID_I", OracleType.Int32).Value = deptid;
                cmd.Parameters.AddWithValue("PV_NUM_EMPLOYEES_O", OracleType.Int32).Direction = ParameterDirection.Output;
    
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
