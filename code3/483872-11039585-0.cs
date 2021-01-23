    private void filterButton_Click(object sender, EventArgs e)
    {
        dataGridView1.Columns.Clear();
        MessageBox.Show(nameFilter.Text);
        InitializeComponent();
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\qwe.accdb;";
        try
        {
            using (DataTable dt = new DataTable())
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(new SqlCommand("SELECT id FROM table1",new OleDbConnection(connectionString))))
                    {
                        da.Fill(dt);
                        MessageBox.Show(dt.Rows.Count.ToString());
                        dataGridView1.DataSource = dt;
                        dataGridView1.Update();
                    }
                }       
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
    }
