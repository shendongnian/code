    try
    {
      string MyConString = "Data Source=localhost;User Id= yourusername;Password=yourpassword;";
      using (OracleConnection connection = new OracleConnection(MyConString))
      {
      connection.Open();
      sqldb1 = "select * from DEMO_CUSTOMERS;";
      using (OracleCommand cmdSe1 = new OracleCommand(sqldb1, connection))
      {
        DataTable dt = new DataTable();
        OracleDataAdapter da = new OracleDataAdapter(cmdSe1);
        da.Fill(dt);
        db1.ItemsSource = dt.DefaultView;
      }
      connection.Close();
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.ToString());
    }
