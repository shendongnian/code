    private void Form_Load(object sender, EventArgs e)
    {
        productsComboBox.DataSource = GetAllProducts();
        productsComboBox.DisplayMember = "Name";
        productsComboBox.ValueMember = "Id";
    }
    
    private IList<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        // I use ConfigurationManager from System.Configuration.dll 
        // to read connection strings from App.config
        string connectionString = ConfigurationManager.ConnectionStrings["anbar"].ConnectionString;
    
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
    
            while (reader.Read())
            {
                products.Add(new Product() { Id = (int)reader["Id"],
                                             Name = (string)reader["Name"],
                                             Quantity = (int)reader["Quantity"] });
            }
        }
        return products;
    }
