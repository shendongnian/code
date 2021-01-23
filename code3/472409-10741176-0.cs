        private void dgvPermit_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo Hti;
            if (e.Button == MouseButtons.Right)
            {
                Hti = dgv.HitTest(e.X, e.Y);
                if (Hti.Type == DataGridViewHitTestType.Cell)
                {
                    if (!((DataGridViewRow)(dgv.Rows[Hti.RowIndex])).Selected)
                    {
                        dgv.ClearSelection();
                        ((DataGridViewRow)dgv.Rows[Hti.RowIndex]).Selected = true;
                    }
                }
            }
            
        }
