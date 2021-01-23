    private void Form1_Load(object sender, EventArgs e)
    {
        FormatGrid();
        GetData();
    }
    private void FormatGrid()
    {
        DataGridViewTextBoxColumn tb1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn tb2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn tb3 = new DataGridViewTextBoxColumn();
        dataGridView1.Columns.Add(tb1);
        dataGridView1.Columns.Add(tb2);
        dataGridView1.Columns.Add(tb3);
        dataGridView1.Columns[0].HeaderText = "TextBox1";
        dataGridView1.Columns[1].HeaderText = "TextBox2";
        dataGridView1.Columns[2].HeaderText = "TextBox3";
    }
    private void GetData()
    {
        SqlConnection cn = new SqlConnection("data source=localhost;initial catalog=acc;uid=sa;pwd=emotions");
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("select top 6 GRNo, SName, FName from Students", cn);
        dt.Clear();
        da.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2]);
        }            
    }
    private void button1_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
    } 
      
