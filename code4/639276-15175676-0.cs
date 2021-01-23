    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        var productName = comboBox2.Text;
        if (!string.IsNullOrEmpty(productName)) {
            DataSet d = GetProductInfo(productName);
            if (d.Tables.Count > 0)
            {
                textBox2.Text = d.Tables[0].Rows[0]["Quantity"].ToString();
                textBox3.Text = d.Tables[0].Rows[0]["Color"].ToString();
                textBox4.Text = d.Tables[0].Rows[0]["Size"].ToString();
                textBox5.Text = d.Tables[0].Rows[0]["Price"].ToString();
            }
        }
    }
