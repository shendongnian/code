    decimal price;
    if(!decimal.TryParse(txt_price.Text, out price))
    {
       //code to display message that txt_price doesn't have a valid value.
       return;
    }
    using(var con = /*your code that constructs the connection*/)
    {
      using(autoInsert = /*your code that returns to command*/)
      {
        autoInsert.Parameters.Add(new NpgsqlParameter("price", NpgsqlDbType.Numeric));
        autoInsert.Parameters[0].Value = price;
        con.Open();
        autoInsert.ExecuteNonQuery();
        con.Close();
      }
    }
