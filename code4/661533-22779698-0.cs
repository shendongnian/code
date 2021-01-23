    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (comboBox1.SelectIndex < 0) 
        {
            // Don't want to suffer database hit if nothing is selected
            // Simply clear text boxes and return
            NameBox.Text = "";
            AddressBox.Text = "";
        }
        else 
        {
            MySqlConnection cs = new MySqlConnection(connectionSQL);
            cs.Open();
            DataSet ds = new DataSet();
            // You only need to select the address since you already have the name unless 
            // they are displayed differently and you want the database display to show
            MySqlDataAdapter da = new MySqlDataAdapter("Select address from Teacher WHERE name='" + comboBox1.Text + "'", cs);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(da);
            da.Fill(ds);
            NameBox.Text = comboBox1.Text;
            AddressBox.Text = ds.Tables[0].Rows[0]["address"].ToString();
        }
    }
