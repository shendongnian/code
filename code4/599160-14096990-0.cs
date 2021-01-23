    private void buttonDelete_Click(object sender, RoutedEventArgs e)
    {            
        SqlConnection cn = new SqlConnection(@"Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=(local)");
        SqlCommand cmd = new SqlCommand("DeleteCustomer", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Original_CustomerID", textBox_CompanyID.Text);
        
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        lbxCustomers.Items.Clear();
        this.init();
    }
