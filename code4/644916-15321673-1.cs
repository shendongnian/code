    private void DBGui_Load(object sender, EventArgs e)
    {
        dataGridView1.DataSource = playersTblBindingSource;
        dataGridView1.DataBind(); // you are missing this
        playersTblBindingSource.DataSource = DB.GamesTbls;
    }
