        private void cbMun()
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand("SELECT munname,idmun from municipality", conn);
            DataTable cbMun = new DataTable();
            adapter.Fill(cbMun);
            comboBox1.DataSource = cbMun;
            comboBox1.DisplayMember = "munname";
            comboBox1.ValueMember = "idmun";
            comboisloading = false;
        }
---------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboisloading)
                return;
            string sql;
            if (comboBox1.SelectedIndex >= 0)
            {
                comboBox2.Items.Clear();
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
        }
