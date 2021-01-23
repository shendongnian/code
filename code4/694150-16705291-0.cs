            DataGridView dgv= (DataGridView)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    dgv.CurrentCell = dgv[gvw.HitTest(e.X, e.Y).ColumnIndex, dgv.HitTest(e.X, e.Y).RowIndex];
                }
            }
