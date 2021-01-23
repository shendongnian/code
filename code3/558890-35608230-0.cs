    private void gridVendorInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                string vendorName = "";
                if (e.ColumnIndex == 0)
                {
                    vendorName = gridVendorInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
