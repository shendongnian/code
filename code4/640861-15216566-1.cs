    using System;
    using System.Configuration;
    using System.Data;
    using MySql.Data.MySqlClient;
    
    public static class mydatautility//change to Utilities
    {
        public mydatautility()//not required in this scenario
        {
        }
        public static DataTable Table(string query) //change method name to GetTable
        {
            string constr = ConfigurationManager.ConnectionStrings["db_con"].ConnectionString;
            DataTable table = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Close();//not required
                    using(MySqlCommand com = new MySqlCommand(query, con))
                    {
                    MySqlDataAdapter da = new MySqlDataAdapter(com);
                    con.Open();
                    da.Fill(table);
                    con.Close();
                    da = null;// reduntant, not required
                    com = null;// reduntant, not required
                    con.Dispose();// reduntant, not required
                    }
                }
            }
            catch (Exception)
            {
            }
            return table;
        }
        public static bool InsertEmployee(string query)// consider changing int to bool since you only require result of operation
        {
            string constr = ConfigurationManager.ConnectionStrings["db_con"].ConnectionString;
            int done = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    Using(MySqlCommand com = new MySqlCommand(query, con))
                    {
                    con.Open();
                    done = com.ExecuteNonQuery();
                    con.Close();
                    com = null;// reduntant, not required
                    con.Dispose();// reduntant, not required
                    }
                }
            }
            catch (Exception)
            {
            }
            return done > 0; // checks rows affected greater than 0
        }
    }
