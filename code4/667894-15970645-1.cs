    using (var connection = new SqlConnection("connection string"))
    {
        connection.Open();
        using (var cmd = new SqlCommand("SELECT * FROM Product WHERE ProductID=@MYVALUE", connection))
        {
            cmd.Parameters.Add("@MYVALUE", SqlDbType.VarChar).Value = textBox3.Text;
            SqlDataReader re = cmd.ExecuteReader();
            if (re.Read())
            {
                textBox4.Text = re["ProductTitle"].ToString(); // only fills using first product in table
                textBox5.Text = re["ProductPublisherArtist"].ToString();
                comboBox1.Text = re["ProductType"].ToString();
                textBox6.Text = re["Price"].ToString();
            }
            else
            {
                MessageBox.Show("Please enter a valid item barcode");
            }
        }
    }
