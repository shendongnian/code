    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        ThisAddIn th = new ThisAddIn();
        //Declare a DataTable and call to GetDetails
        DataTable dt =  th.GetDetails();
        this.dataGridView1.Visible = true;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = dt;
    }
