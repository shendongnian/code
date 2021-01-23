    private void frmMain_Load(object sender, EventArgs e)
    {
        cboFromCurrency.Items.Clear();
        cboComboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        cboComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        // Load data in comboBox => cboComboBox1.DataSource = .....
        // Other things
    }
    
    private void cboComboBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        cboComboBox1.DroppedDown = false;
    }
