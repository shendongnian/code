    //5: Adding values in DataColumns       
                    for (int i = 0; i < products.Count; i++)
                    {
    
                        //foreach (Product item in products)
                        //{
                        Product item = products[i];
                        drow = dt.NewRow();
                        dt.Rows.Add(drow);
                        dt.Rows[i][col1] = item.ProductName.ToString();// i.ToString();
                        dt.Rows[i][col2] = item.ProductDescription.ToString();
                        dt.Rows[i][col3] = String.Format("{0:C}", item.Price);
                        dt.Rows[i][col4] = String.Format("{0:.00}", item.Price);
                        //}
    
                    }
