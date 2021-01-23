    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
        // Better to be safe here.....
        if (this.comboBox1.SelectedValue == null)
            return;
        using(OleDbConnection con = new OleDbConnection(connectionString))
        using(OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT * FROM ["     +this.comboBox1.SelectedValue.ToString() +"]", con))
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da2.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da2.Fill(dt);
            this.dataGridView1.DataSource = dt; 
        }
    }
