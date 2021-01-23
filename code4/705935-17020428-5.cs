        public bool Editable {get;set;}
        int i;
        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(Editable) return;
            if(i == e.RowIndex)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    if (cell.Value == null)
                    {                        
                        return;
                    }
                }
                e.Cancel = true;                
            }
            else if (dataGridView1.Rows.Count - 1 != e.RowIndex)
            {
                e.Cancel = true;
            }
            else i = e.RowIndex;            
        }
