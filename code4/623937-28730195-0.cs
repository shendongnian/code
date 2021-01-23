     private void dgViewOrderList_CellValidated(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 0 && dgViewOrderList.CurrentCell.Value != null)
                {
                    var cellValue = dgViewOrderList.CurrentCell.Value.ToString();
                    var isExist = dgViewOrderList.Rows.Cast<DataGridViewRow>().Count(c =>c.Cells[0].EditedFormattedValue.ToString() == cellValue) > 1;
                    if (isExist)
                    {
                        dgViewOrderList.CurrentCell.Value = null;
                    }
                }
            }
        }
