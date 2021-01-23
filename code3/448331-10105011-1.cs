        public static DataTable ToDataTable(DataContext ctx, object query) // ctx is your data context, & query is your linq query 
        {
            IDbCommand cmd;
            try
            {
                cmd = ctx.GetCommand(query as IQueryable);
            }
            catch
            {
                throw new Exception("Could not connect database");
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                
            }
            catch
            {
                cmd.Connection.Close();
                throw new Exception("Could not connect database");
            }
            try
            {
                adapter.Fill(dt);
                cmd.Connection.Close();
            }
            catch(Exception ex)
            {
                cmd.Connection.Close();
                throw new Exception("Query Parsing Error");
            }
            return dt;
        }
