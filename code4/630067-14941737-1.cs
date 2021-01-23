      // MyContacts db has a table Person with primary key (ID) - 3 rows - IDs 4,5,6
      SqlConnection myConnection = new SqlConnection("Data Source=.; Initial Catalog=MyContacts; Integrated Security=SSPI; Persist Security Info=false; Trusted_Connection=Yes");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select * from Person", myConnection);
            myConnection.Open();
            
            DataSet dashboardDS = new DataSet();
            da.Fill(dashboardDS, "Person");
            dashboardDS.Tables[0].PrimaryKey = new[] { dashboardDS.Tables[0].Columns["ID"]}; 
            List<int> ids = new List<int> {4, 6, 7};
            foreach (var id in ids)
            {
                if (dashboardDS.Tables[0].Rows.Find(id) == null)
                {
                    Console.WriteLine("id not in database {0}", id); //i.e. 7
                }
            }
