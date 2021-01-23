    foreach(char ch in containsRelatedProductsStringOnly.Rows[0]["SKURelatedProducts"].ToString()) 
    {
         if(ch != ' ')
         {
             stockCode = stockCode + ch;
         }
         else
         {
             SqlCommand cmd2 = new SqlCommand("SELECT SKUName FROM COM_SKU WHERE SKUStockCode = '" + stockCode+"'", con);
             SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
             adapter2.Fill(containsAllRelatedProductData); //Error
             stockCode = "";
         }
    }
