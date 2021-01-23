    StringBuilder sb = new StringBuilder();
                foreach (SqlParameter param in sqlParams)
                {
                    sb.Append("declare " + param.ParameterName + " as " + param.SqlDbType + Environment.NewLine);
                    sb.Append("set " + param.ParameterName + " = " + param.Value + Environment.NewLine);
                }
                string sqlTestString = sb.ToString();
