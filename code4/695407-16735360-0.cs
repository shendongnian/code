    public string passData = ""; 
    private void btnAddNewRecord_Click(object sender, EventArgs e)
    {
        var formAddRecord = new FormNewRecord();
        formAddRecord.ShowDialog(this); //important
    }
    private void Form1_Load()
    { populating combobox...}
    private void dataOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        IMyCustomData data = (IMyCustomData)dataOptions.SelectedItem;
        passData = data.ToString();   //store the selected value to passData
    }
