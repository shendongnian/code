    // Here I do this in the form constructor - there are other places you can do it
    public Form1()
    {
        InitializeComponent();
        DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
        // You need to set some properties on the column to make it work
        // Datasource is the source (usually a list) of objects to show in the combobox
        col.DataSource = dataSource;
        col.DataPropertyName = "ColumnInGridDataSource";
        col.DisplayMember = "DisplayProperty";
        col.ValueMember = "ValueProperty";
        dataGridView1.Columns.Add(col);
        // This hides the textboxcolumn
        dataGridView1.Columns["YourTextBoxColumnName"].Visible = false;
    }
