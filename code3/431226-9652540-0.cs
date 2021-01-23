        protected static List<string> listSetValues = new List<string>();
        public static List<string> myfunction()
        {
            cmd = new SqlCommand("SELECT * FROM category", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listSetValues.Add(dr[0].ToString());
            }
            con.Close();
            return listSetValues;
        }
