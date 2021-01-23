    private void dgv_Items_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
                {
                    try
                    {
                        if (MessageBox.Show("Do you want to delete the current row?", "Confirm deletion",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ScrollPosition = 0;
                            ScrollPosition = dgv_Items.FirstDisplayedScrollingRowIndex;
                            int iIndex = dgv_Items.CurrentRow.Index;
         
                                DataRow dr = gdt.Rows[iIndex]; //new added code
                                gdt.Rows.RemoveAt(iIndex);
                                gdt.Rows.InsertAt(dr, iIndex); //new added code
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
