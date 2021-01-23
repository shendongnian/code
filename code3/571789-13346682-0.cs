    private void dataGV_CellCoubleClick(object sender, DataGridCellEventArgs e)
    { 
        if (e.ColumnIndex == 0)
        {
            string strCaseNo = ((DataGridView)sender).Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString();
            frmCase fC = new frmCase(strCaseNo);
            fC.MdiParent = this.MdiParent;
            fC.Show;
        }
    }
