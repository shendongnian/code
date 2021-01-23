        List<string> names = new List<string> { "Joe", "Jane", "Jack" };
        using (SqlConnection cnn = new SqlConnection("..."))
        {
          cnn.Open();
          using (SqlCommand cmd = new SqlCommand("getPersonnelList", cnn))
          {
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tvparameter = new DataTable();
            tvparameter.Columns.Add("Name", typeof(string));
            foreach (string name in names)
            {
              tvparameter.Rows.Add(name);
            }
            cmd.Parameters.AddWithValue("@NamesTable", tvparameter);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
              while (dr.Read())
              {
                Console.WriteLine("{0} - {1}", dr["ID"], dr["Name"]);
              }
            }
          }
        }
