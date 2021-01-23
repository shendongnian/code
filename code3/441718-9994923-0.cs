    private void autoSizeDGV(DataGridView dgv)
        {
            try
            {
                //Step 1
                dgv.AutoResizeColumns();
                //Step 2
                int totalcellwidth = 0;
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    totalcellwidth += dgv.Columns[i].Width;
                }
                //Step 3
                int widthtoadd = (dgv.Width - totalcellwidth) / dgv.ColumnCount;
                //Step 4
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    Debug.WriteLine("previous dgv.Columns[" + i + "]: " + dgv.Columns[i].Width);
                    dgv.Columns[i].Width += widthtoadd;
                    Debug.WriteLine("after dgv.Columns[" + i + "]: " + dgv.Columns[i].Width);
                }
            }
