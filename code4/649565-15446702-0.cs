    public Form1()
    {
            InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
            AddComboxBoxControlsInGridViewColumn();
    }
    
    private void AddComboxBoxControlsInGridViewColumn()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Status");
        for (int j = 0; j < 10; j++)
        {
            dt.Rows.Add("");
        }
        this.dataGridView1.DataSource = dt;
        this.dataGridView1.Columns[0].Width = 200;
    
        DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();
        ComboBoxCell.Items.AddRange(new string[] { "Pending","Accepted","Rejected" });
        this.dataGridView1[0, 0] = ComboBoxCell;
        this.dataGridView1[0, 0].Value = "Accepted";
    }
