           string returnValue = string.Empty;
             ...............
            SqlConn.Open();
            sqlcomm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@inputdata", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = Username;
            sqlcomm.Parameters.Add(param);
            SqlParameter retval = sqlcomm.Parameters.Add("@outputdata", SqlDbType.VarChar);
            retval.Direction = ParameterDirection.Output;
            string retunvalue = (string)sqlcomm.Parameters["@outputdata"].Value;
             ......................
             .........
