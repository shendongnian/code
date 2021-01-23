    private int getPkRowReport()
    {
        if (dgvReportGrid.SelectedRows.Count > 0)
        {
            //get selected row index
            int index = this.dgvReportGrid.SelectedRows[0].Index;
            //get pk of selected row using index
            string cellValue = dgvReportGrid["rptNo", index].Value.ToString();
            //change pk string to int
            int pKey = Int32.Parse(cellValue);
            return pKey;
        }
        else
        {
            return -1;
        }
    }
