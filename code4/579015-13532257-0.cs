    private void dgvPayment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
            {
                for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
                {
                    DataGridViewRow row = dgvPayment.Rows[index];
                    Payment lPayment = row.DataBoundItem as Payment;
                    if (lPayment != null && lPayment.IsLocked)
                    {
                        row.DefaultCellStyle.BackColor = Color.Pink;
                        row.ReadOnly = true;
                    }
                    else
                    {
                        row.DefaultCellStyle = null;
                        row.ReadOnly = false;
                    }
    
                        
                }
            }
