    private void ButtonSell_Click(object sender, EventArgs e)
    {
        Product product = productsComboBox.SelectedItem as Product;
        int qtyToSell = (int)qtyToSellNumericUpDown.Value;
        SellProduct(product, qtyToSell);
        product.Quantity -= qtyToSell; // update product
        qtyTextBox.Text = product.Quantity.ToString(); // update current quantity 
    }
    private void SellProduct(Product product, int qtyToSell)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["anbar"].ConnectionString;
    
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Products SET Quantity = @Quantity WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity - qtyToSell);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
