public static void Main(string[] args)
        {
            DataGrid dg1 = new DataGrid();
            DataGrid dg2 = new DataGrid();
            DataGrid dg3 = new DataGrid();
            DataSet ds = GetData(@"select * from table1;
                                        select * from table2;
                                        select * from table3");
            dg1.DataSource = ds.Tables[0];
            dg1.DataBind();
            dg2.DataSource = ds.Tables[1];
            dg2.DataBind();
            dg3.DataSource = ds.Tables[2];
            dg3.DataBind();
        }
        public static DataSet GetData(string sqlQuery) {
            try
            {
                DataSet ds = new DataSet();
                // set your connection here
                SqlConnection conn = new SqlConnection("");
                // execute query with your connection
                SqlDataAdapter adapt = new SqlDataAdapter(sqlQuery, conn);
                // open connection, fill data and close
                conn.Open();
                adapt.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
