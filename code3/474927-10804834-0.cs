    private void Form1_Load(object sender, EventArgs e)
    {
        PopulateComboBoxes();
        // Make 32 rows total
        for (int i = 0; i <= 30; i++)
        {
            dataGridView1.Rows.Add();
        }
    }
    
    private void PopulateComboBoxes()
    {
        //for each column, set as combobox, then populate
        var cName = new DataGridViewComboBoxColumn();
        cName.Items.Add("John Galt");
        cName.Items.Add("Tim Duncan");
        cName.Items.Add("King Leonidas");
        var cAddress = new DataGridViewComboBoxColumn();
        cAddress.Items.Add("Main Street");
        cAddress.Items.Add("Broad Street");
        cAddress.Items.Add("Market Street");
    
        dataGridView1.Columns.Add(cName);
        dataGridView1.Columns.Add(cAddress);
    
    }
