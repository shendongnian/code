    private bool firstColEdited = false;
    /************************************************************/
    var source = new AutoCompleteStringCollection();
    String[] stringArray = Array.ConvertAll<DataRow, String>(products.Select(), delegate(DataRow row) { return (String)row["code"]; });
    source.AddRange(stringArray);
    /************************************************************/
    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        TextBox txtbox = e.Control as TextBox;
        if (this.dataGridView1.CurrentCell.ColumnIndex == 0 || firstColEdited)
        {
            firstColEdited = true;
            txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbox.AutoCompleteCustomSource = source;
            txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
     }
