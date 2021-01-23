        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateEmployeeSalary(int percentage, int deptid, int posid)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            OracleCommand cmd = new OracleCommand("GIVE_RAISE_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PV_PERCENTAGE_RAISE_I", OracleType.Int32).Value = percentage;
            cmd.Parameters.AddWithValue("PV_POSITIONID_I", OracleType.Int32).Value = posid;
