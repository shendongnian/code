        private void dgVData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgVData.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }
        }
