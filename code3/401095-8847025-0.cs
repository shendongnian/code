    public Form1()
    {
        InitializeComponent();
        this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dataGridViewColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewColumnName.MinimumWidth = 60;
    }
