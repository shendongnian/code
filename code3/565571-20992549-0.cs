    //     This is the exact code for search facility in datagridview.
           private void buttonSearch_Click(object sender, EventArgs e)
           {
            string searchValue=textBoxSearch.Text;
            int rowIndex = 1;
            //string first_row_data=dataGridView1.Rows[0].Cells[0].Value.ToString() ;
           
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResulet = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[rowIndex].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dataGridView1.Rows[rowIndex].Selected = true;
                        rowIndex++;
                        valueResulet = false;
                    }
                }
                if (valueResulet != false)
                {
                    MessageBox.Show("Record is not avalable for this Name"+textBoxSearch.Text,"Not Found");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
}
