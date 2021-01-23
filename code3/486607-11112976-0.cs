        private int CountLines(DataGridView dataGridView)
        {
            int totalLineCount = 0;
            using (Graphics graphics = Graphics.FromHwnd(this.Handle))
            {
                SizeF baselineSize = graphics.MeasureString("test line", dataGridView.Font);
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    int cellLineCount = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null)
                        {
                            continue;
                        }
                        string value = cell.Value.ToString();
                        SizeF size = graphics.MeasureString(value, dataGridView.Font, cell.Size.Width);
                        int lines = (int)Math.Round(size.Height / baselineSize.Height);
                        cellLineCount = Math.Max(cellLineCount, lines);
                    }
                    totalLineCount += cellLineCount;
                }
            }
            return totalLineCount;
        }
