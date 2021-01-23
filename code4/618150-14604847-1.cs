    private void gridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colName)
            {
                var age = Convert.ToInt32(gridView.GetRowCellValue(e.RowHandle, colAge));
                if (age < 18)
                    e.Appearance.BackColor = Color.FromArgb(0xFE, 0xDF, 0x98);
                else
                    e.Appearance.BackColor = Color.FromArgb(0xD2, 0xFD, 0x91);
            }
        }
