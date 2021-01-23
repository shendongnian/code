    try
                {
                    int idx = dataGridInfo.CurrentRow.Index;
                    this.getInfoFilmDS.sp_getInfo.Rows[idx].Delete();
                    sp_getInfoTableAdapter.Adapter.Update(getInfoFilmDS);
                    MessageBox.Show("Data removed", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Delete Data" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
