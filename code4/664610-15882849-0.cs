     public StoredProcExecutionException(string message, Exception innerException ,SqlCommand sqlCommand)
                : base(Convert.ToString(sqlCommand.CommandType ,CultureInfo.InvariantCulture)+" : "
                    + Convert.ToString(sqlCommand.CommandText, CultureInfo.InvariantCulture)
                    + "Failed. " + Convert.ToString(message, CultureInfo.InvariantCulture), innerException)
            {
                StringBuilder sb = new StringBuilder();
    
                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    if (sb.Length > 0) sb.Append(",");
                    sb.AppendFormat("{0}='{1}'", param.ParameterName, Convert.ToString(param.Value, CultureInfo.InvariantCulture));               
                }
    
                StringBuilder sbHeader = new StringBuilder();
                sbHeader.AppendLine(String.Format(CultureInfo.InvariantCulture,"{0} :{1} Failed. {2}", sqlCommand.CommandType, sqlCommand.CommandText, message));
                sbHeader.AppendFormat("Exec {0} ", sqlCommand.CommandText);
    
                sbHeader.Append(sb.ToString());
    
            }
