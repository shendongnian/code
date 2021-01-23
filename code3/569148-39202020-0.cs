        void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv.Columns[dgv.CurrentCell.ColumnIndex].GetType() == typeof(DataGridViewCheckBoxColumn))
            {
                if (dgv.Columns[dgv.CurrentCell.ColumnIndex].DataPropertyName.StartsWith("_nodb_"))
                {
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }            
        }
