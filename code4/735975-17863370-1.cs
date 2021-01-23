                SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=Test;integrated security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customer", conn);
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                var a = (from d in dataSet.Tables[0].Rows.Cast<DataRow>()
                        select new Customer() {
                            Id = (Guid)d[0],
                            Name = d[1].ToString(),
                            Age = Convert.ToInt32(d[2]), 
                            Email = d[3].ToString()
                        }).ToList();
