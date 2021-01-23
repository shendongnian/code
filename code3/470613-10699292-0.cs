    using System.Data.SqlClient;
    string resultVar = String.Empty;
    string ServerName="localhost";
    string DatabaseName="foo";
            SqlConnection conn=new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI",ServerName,DatabaseName));
            SqlCommand cmd=new SqlCommand(Query,conn);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                throw new InvalidOperationException(String.Format(
                    "Connection error: {0} Num:{1} State:{2}",
                    se.Message,se.Number, se.State));
            }
            resultVar = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
            
