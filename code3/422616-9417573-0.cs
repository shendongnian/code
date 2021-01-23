     string selectProductStatement = @"           SELECT 
                                                  Products.Code, 
                                                  Products.Description,
                                                  Products.Category, 
                                                  Products.Price, 
                                                  BookProducts.Author
                                                  FROM Products
                                                  INNER JOIN BookProducts 
                                                  ON (Products.@ProductID = BookProducts.ProductID) ";
                string connectionString = string.Empty;
    
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
    
                    using (SqlCommand sqlCommand = new SqlCommand(selectProductStatement, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@productID", productID);
    
                        //Etc
                    }
                }
