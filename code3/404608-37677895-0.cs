    DataGridViewColumn DataGridViewColumnSelected;   
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
                        if (e.ColumnIndex !=-1 && e.RowIndex == -1)
                        {
                            DataGridViewColumnSelected = dataGridView1.Columns[e.ColumnIndex] as DataGridViewColumn;
                            
                        }
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                bool bHandled = false;
                switch (keyData)
                {
                    case Keys.Delete:
                        if (DataGridViewColumnSelected != null)
                        {
                            this.dataGridView1.Columns.RemoveAt(DataGridViewColumnSelected.Index);
                            //dataGridView1.Columns[DataGridViewColumnSelected.Name].Visible = false;  // case of just hiding the column
                        }
                        break;
                }
                return bHandled;
            }
