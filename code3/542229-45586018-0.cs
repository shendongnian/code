    public SqlConnection GetSqlConnection()
            {
                SqlConnection sql = new SqlConnection();
                sql.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SchoolContext"].ToString();
                return sql;
            }
