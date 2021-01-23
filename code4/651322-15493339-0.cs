    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
        string sql;
            MySqlConnection conn = new MySqlConnection(sqlString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        sql = "SELECT brgyname,idbrgy from barangay where idmun=" + comboBox1.SelectedValue;
        adapter.SelectCommand = new MySqlCommand(sql, conn);
        DataTable cbBrgy = new DataTable();
        adapter.Fill(cbBrgy);
        comboBox2.DataSource = cbBrgy;
        comboBox2.DisplayMember = "brgyname";
        comboBox2.ValueMember = "idbrgy";
    }
