        private void FooDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(chkMultiSort.Checked == true)
            {
                string columnHeader = FooDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                txtMultiSort.Text += (columnHeader + ", ");
                try
                {
                    FooBindingSource.Sort = txtMultiSort.Text.Remove(txtMultiSort.Text.Length - 2);
                }
                catch
                {
                    MessageBox.Show("Invalid Sort Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtMultiSort.Text = String.Empty;
                }
            }
          
        }
        private void ChkMultiSort_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMultiSort.Checked == true)
            {
                txtMultiSort.Visible = true;
            }
            else
            {
                txtMultiSort.Visible = false;
                txtMultiSort.Text = String.Empty;
            }
        }
        private void TxtMultiSort_DoubleClick(object sender, EventArgs e)
        {
            txtMultiSort.Text = String.Empty;
        }
    
