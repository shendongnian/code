public static void Main(string[] args)
        {
            DataGrid dg1 = new DataGrid();
            DataGrid dg2 = new DataGrid();
            DataGrid dg3 = new DataGrid();
            dg1.DataSource = GetData("select * from table1");
            dg1.DataBind();
            dg2.DataSource = GetData("select * from table2");
            dg2.DataBind();
            dg3.DataSource = GetData("select * from table3");
            dg3.DataBind();
        }
        public static DataTable GetData(string sqlQuery) {
            try
            {
                DataTable dt = new DataTable();
                // set your connection here
                SqlConnection conn = new SqlConnection("");
                // execute query with your connection
                SqlDataAdapter adapt = new SqlDataAdapter(sqlQuery, conn);
                // open connection, fill data and close
                conn.Open();
                adapt.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
