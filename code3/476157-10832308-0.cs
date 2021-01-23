     private void SortGridView(string sortExpression, string sortDir, string filter)
            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = WebConfigurationManager.ConnectionStrings[1].ConnectionString;
    
                if (filter == "*")
                {
                    command.CommandText = "SELECT * FROM Products ORDER BY " + sortExpression + " " + sortDir;
                }
                else if (filter == "on_sale")
                {
                    command.CommandText = "SELECT * FROM Products INNER JOIN ProductVariants ON [Products].product_id = [ProductVariants].product_id WHERE [ProductVariants].on_sale = 1 ORDER BY [Products]." + sortExpression + " " + sortDir;
                }
                else
                {
                    command.CommandText = "SELECT * FROM Products WHERE " + filter + " = 1 ORDER BY " + sortExpression + " " + sortDir;
                }
    
                command.Connection = connection;
    
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sqlAdapter.Fill(ds);
    
                DataTable dt = new DataTable();
    
                dt = ds.Tables[0];
    
                gvAllProducts.DataSource = dt;
            }
