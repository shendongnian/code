    ....
    else
    {
        using(var con =  new SqlConnection("Data Source=localhost;Initial Catalog=ROG;Integrated Security=True"))
        using (var daProduct = new SqlDataAdapter("SELECT * FROM ProductDB WHERE Product_Line = @Product_Line", con))
        {
            daProduct.SelectCommand.Parameters.Add("@Product_Line", SqlDbType.VarChar, 50).Value = TextBox1.Text;
            dsProduct = new DataSet();
            daProduct.Fill(dsProduct, "Product_Line");
        }
    }
       
