    // Retrieve the individual sub-category cell
    DataGridViewComboBoxCell subComboCell = datagrdADDTEMP.Rows[j].Cells[cmbDataGridSubCategory.Index];
    // Alter its DataSource
    subComboCell.DataSource = ds.Tables[0];
    subComboCell.DisplayMember = "SubCategoryName";
    subComboCell.ValueMember = "SubCategoryCode";
