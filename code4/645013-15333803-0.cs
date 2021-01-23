      public bool AddObject(ref T_COMN_CUSTOMER_BANK_ACC_Entity Obj)
        {
            bool result = false;
            OracleCommand Comm = new OracleCommand(InsertCommandName, Connection);
            Comm.CommandType = CommandType.StoredProcedure;
            Comm.Parameters.Add("p_CUSTOMER_ID", OracleType.Number).Value = Obj.CUSTOMER_ID;
            Comm.Parameters.Add("p_CUSTOMER_TP_ID", OracleType.Number).Value = Obj.CUSTOMER_TP_ID;
            Comm.Parameters.Add("p_CUSTOMER_BANK_ACC_ID", OracleType.Number).Direction = ParameterDirection.Output;
            Comm.Parameters.Add("p_BANK_ID", OracleType.Number).Value = Obj.BANK_ID;
            Comm.Parameters.Add("p_IBAN", OracleType.NVarChar, 200).Value = Obj.IBAN;
            Comm.Parameters.Add("p_IS_DELETED", OracleType.Number).Value = Obj.IS_DELETED;
            Comm.Parameters.Add("p_CREATED_BY", OracleType.NVarChar, 200).Value = Obj.CREATED_BY;
            Comm.Parameters.Add("p_CREATED_DT", OracleType.DateTime).Value = Obj.CREATED_DT;
            Comm.Parameters.Add("p_MODIFIED_BY", OracleType.NVarChar, 200).Value = Obj.MODIFIED_BY;
            Comm.Parameters.Add("p_MODIFIED_DT", OracleType.DateTime).Value = Obj.MODIFIED_DT;
            if (ExecuteSqlCommand(Comm) > 0)
            {
                result = true;
                Obj.CUSTOMER_BANK_ACC_ID = (decimal)Comm.Parameters["p_CUSTOMER_BANK_ACC_ID"].Value;
            }
            return result;
        }
