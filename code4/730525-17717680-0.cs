    public string getproductdetail(int ID)
        {
            Product prod = new Product();
        String product_no=Convert.ToString(Id);
            string connectionString =
              "server=server;uid=user;pwd=pwd;database=DB;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Select name from dbo.product(nolock) Where product_no = " + product_no.ToString();
                connection.Open();
          SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prod.name          = reader["name"].ToString();
                }
            }
        }
        }
        [DataContract]
        public class Product
        {
        [DataMember]
        public string name;
        }
