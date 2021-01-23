    using(SqlConnection sc = new SqlConnection()) {
      sc.ConnectionString = "Data Source=localhost;Initial Catalog=LoginScreen;Integrated Security=True";
      sc.Open();
  
      using (SqlCommand com = sc.CreateCommand()) {
        com.CommandText =
          "insert into Stock(\n" + 
          "  Prod_Id,\n" + 
          "  Prod_Name,\n" +
          "  Prod_Cat,\n" +
          "  Supplier,\n" +
          "  Cost,\n" +
          "  Price_1,\n" +
          "  Price_2,\n" +
          "  Price_3)\n" +
          "values(\n" +
          "  @prm_Prod_Id,\n" +
          "  @prm_Prod_Name,\n" +
          "  @prm_Prod_Cat,\n" +
          "  @prm_Supplier,\n" +
          "  @prm_Cost,\n" +
          "  @prm_Price_1,\n" +
          "  @prm_Price_2,\n" +
          "  @prm_Price_3)";
  
        //TODO: Change my arbitrary "80" to actual Stock fields' sizes! 
        com.Parameters.Add("@prm_Prod_Id", SqlDbType.VarChar, 80).Value = ProdID.Text;
        com.Parameters.Add("@prm_Prod_Name", SqlDbType.VarChar, 80).Value = ProdName.Text;
        com.Parameters.Add("@prm_Prod_Cat", SqlDbType.VarChar, 80).Value = ProdCat.Text;
        com.Parameters.Add("@prm_Supplier", SqlDbType.VarChar, 80).Value = ProdSub.Text;
        com.Parameters.Add("@prm_Cost", SqlDbType.VarChar, 80).Value = ProdCost.Text;
        com.Parameters.Add("@prm_Price_1", SqlDbType.VarChar, 80).Value = ProdPrice1.Text;
        com.Parameters.Add("@prm_Price_2", SqlDbType.VarChar, 80).Value = ProdPrice2.Text;
        com.Parameters.Add("@prm_Price_3", SqlDbType.VarChar, 80).Value = ProdPrice3.Text;
        com.ExecuteNonQuery();
      }
    }
