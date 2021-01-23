      public static void UpdateMyObject(string connection, object myobject)
            {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlTransaction trans = con.BeginTransaction())
                    {
                        WorkingMethod1(con, myobject);
                        WorkingMethod2(con, myobject);
                        WorkingMethod3(con, myobject);
                        trans.Commit();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOMETHING BAD HAPPENED!!!!!!!  {0}", ex.Message);
            }
        }
        private static void WorkingMethod1(SqlConnection con, object myobject)
        {
            // Do something here against the database
        }
        private static void WorkingMethod2(SqlConnection con, object myobject)
        {
            // Do something here against the database
        }
        private static void WorkingMethod3(SqlConnection con, object myobject)
        {
            // Do something here against the database
        }
