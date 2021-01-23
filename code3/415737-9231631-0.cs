        Dictionary<DataGridViewCell, object> cvDict = new Dictionary<DataGridViewCell, object>();
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell dgcv = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!cvDict.ContainsKey(dgcv))
            {
                cvDict.Add(dgcv, dgcv.Value);
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dgcv = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cvDict.ContainsKey(dgcv))
            {
                if (cvDict[dgcv].Equals(dgcv.Value))
                {
                    cvDict.Remove(dgcv);
                }
            }
        }
