        Form1 f0 = this.Owner as Form1; //_ChangeSupplerInfo 
        supplierVO _SupplierVO = new supplierVO();
        Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
        string SelectedSupplierID = dataGridView1.SelectedCells[0].Value.ToString();
        SupplierCode = SelectedSupplierID;
        _SupplierVO.SupplierCode = SelectedSupplierID;
        f0.FillTextBoxes(SelectedSupplierID);
        this.Close();
