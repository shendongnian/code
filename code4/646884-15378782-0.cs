        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
	           string strConnection = "Data Source=HP\\SQLEXPRESS;database=MK;Integrated Security=true";
	            SqlConnection con = new SqlConnection(strconnection);
	            try
	            {
					con.Open();
	                SqlCommand sqlCmd = new SqlCommand();
	                sqlCmd.Connection = con;
	                sqlCmd.CommandType = CommandType.Text;
	                sqlCmd.CommandText = "select * from " + comboBox1.SelectedValue;
	                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
	                DataTable dtRecord = new DataTable();
	                sqlDataAdap.Fill(dtRecord);
	                dataGridView1.AutoGenerateColumns = true;
	                dataGridView1.DataSource = dtRecord;
	                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
	                con.Close();
	            }
	            catch (Exception ex)
	            {
	                MessageBox.Show(ex.Message);
	            }
            }
        }
