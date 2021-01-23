    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            connection.Open();
            string sql = "Insert into [Order] (customer_id) values (" + Session["Customer_id"] + "); SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            var order_id =  cmd.ExecuteScalar();
            
            connection.Close();
            Console.Write(order_id);
