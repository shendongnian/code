        private string GetDbmsOutputLine()
        {
            OracleCommand command = new OracleCommand
            {
                Connection = <connection>,
                CommandText = "begin dbms_output.get_line(:line, :status); end;",
                CommandType = CommandType.Text
            };
            OracleParameter lineParameter = new OracleParameter("line",  
                OracleType.VarChar);
            lineParameter.Size = 32000;
            lineParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(lineParameter);
            OracleParameter statusParameter = new OracleParameter("status",  
                OracleType.Int32);
            statusParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(statusParameter);
            command.ExecuteNonQuery();
            
            if (command.Parameters["line"].Value is DBNull)
                return null;
            string line = command.Parameters["line"].Value as string;
            return line;
        }
