    private void Form1_Load(object sender, EventArgs e)
    {
         SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
         connectionString.DataSource = @".\SQLEXPRESS";
         connectionString.InitialCatalog = "MyDatabase";
         connectionString.IntegratedSecurity = true;
         MessageBox.Show(connectionString.ConnectionString);
    }
