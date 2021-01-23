    private void button1_Click(object sender, EventArgs e)
    {
        database1DataGridView.Visible = true;
        database2DataGridView.Visible = false;
        database3DataGridView.Visible = false;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        database2DataGridView.Visible = true;
        database1DataGridView.Visible = false;
        database3DataGridView.Visible = false;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        database3DataGridView.Visible = true;
        database1DataGridView.Visible = false;
        database2DataGridView.Visible = false;
    } 
