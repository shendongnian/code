    int queryString =int.Parse(Request.QueryString["Id"]);
            
    SqlConnection conn =new SqlConnection("server=.; Database=Northwind; 
    Integrated Security=true;");
            
    try{
    conn.Open();
    
    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT ProductID, ProductName, UnitPrice, CategoryID FROM Products WHERE CategoryID =@CategoryID", conn);
    
    dataAdapter.SelectCommand.Parameters.Add("@CategoryID", queryString);
                            DataSet dataSet = new DataSet();
                            dataAdapter.Fill(dataSet);
                            QueryStringProductListRepeater.DataSource = dataSet;
                            QueryStringProductListRepeater.DataBind();
    }
    
    catch{
    Response.Write("QueryStringProductListRepeater");
    }
    
    finally{
    conn.Close();
    }
