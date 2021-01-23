    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace SProcRunner
    {
        public class SqlAction
        {
            public SqlAction(string connString)
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connString);
    
                _conn = new SqlConnection(sb.ToString());
            }
    
            private SqlConnection _conn;
    
            public string RunSql(string Sql)
            {
                string result = string.Empty;
    
                // split the sql by "GO"
    
                string[] commandText = Sql.Split(new string[] { String.Format("{0}GO{0}", Environment.NewLine) }, StringSplitOptions.RemoveEmptyEntries);
    
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.Text;
    
                for (int x = 0; x < commandText.Length; x++)
                {
                    if (commandText[x].Trim().Length > 0)
                    {
                        cmd.CommandText = commandText[x];
                        try
                        {
                            cmd.ExecuteNonQuery();
                            result = "Command(s) completed successfully.";
                        }
                        catch (SqlException ex)
                        {
                            result = String.Format("Failed: {0}", ex.Message);
                            break;
                        }
                    }
                }
    
                if (_conn.State != ConnectionState.Closed) _conn.Close();
    
                return result;
            }
        }
    }
