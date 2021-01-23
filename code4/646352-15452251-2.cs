     OracleParameter[] updatestud = new OracleParameter[3];
            updatestud[0] = query.Parameters.Add(":STUDENT_NAME", OracleDbType.Varchar2, STUDENT_NAME, ParameterDirection.Input);
            updatestud[1] = query.Parameters.Add(":STUDENT_ADDRESS", OracleDbType.Varchar2, STUDENT_ADDRESS, ParameterDirection.Input);
            updatestud[2] = query.Parameters.Add("STUDENT_ID", OracleDbType.Int32, STUDENT_ID, ParameterDirection.Input);
          
