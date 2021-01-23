    DataGridViewRow RowSample = new DataGridViewRow();
    DataGridViewComboBoxCell  CellSample = new DataGridViewComboBoxCell();
    CellSample.DataSource = StringList; // list of the string items that I want to insert in ComboBox
    CellSample.Value = StringList[0]; // default value for the ComboBox
    DataGridViewCell cell = new DataGridViewTextBoxCell();
    cell.Value = "CellText"; // creating the text cell
    RowSample.Cells.Add(cell);
    RowSample.Cells.Add(CellSample);
    SampleGridView.Rows.Add(RowSample);
