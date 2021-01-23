        private DataGridView CopyWhereForeColorIsRed(DataGridView dgv)
        {
            var dgv2 = new DataGridView();
            dgv2.Rows.AddRange(dgv.Rows
                .Cast<DataGridViewRow>()
                .Where(a=>a.Cells.Cast<DataGridViewCell>().Any(c=>c.Style.ForeColor == Color.Red))
                .ToArray());
            return dgv2;
        }
