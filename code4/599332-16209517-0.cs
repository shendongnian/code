    public static class MultilineTriming
    {
        private static int _rowMargins;
        public static void Init(ref DataGridView dataGridView)
        {
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            _rowMargins = dataGridView.RowTemplate.Height - dataGridView.Font.Height;
            Unregister(dataGridView);
            dataGridView.CellEndEdit += DataGridViewOnCellEndEdit;
            dataGridView.CellPainting += DataGridViewOnCellPainting;
            dataGridView.RowsAdded += DataGridViewOnRowsAdded;
            dataGridView.Disposed += DataGridViewOnDisposed;
        }
        private static void DataGridViewOnRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewRow row = view.Rows[e.RowIndex];
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.FormattedValue == null)
                {
                    continue;
                }
                Size size = TextRenderer.MeasureText((string)cell.FormattedValue, view.Font);
                row.Height = Math.Max(size.Height + _rowMargins, row.Height);
            }
        }
        private static void DataGridViewOnDisposed(object sender, EventArgs eventArgs)
        {
            DataGridView dataGridView = sender as DataGridView;
            Unregister(dataGridView);
            
        }
        public static void Unregister(DataGridView dataGridView)
        {
            dataGridView.RowsAdded -= DataGridViewOnRowsAdded;
            dataGridView.CellEndEdit -= DataGridViewOnCellEndEdit;
            dataGridView.CellPainting -= DataGridViewOnCellPainting;
        }
        private static void DataGridViewOnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            string text = (string)cell.FormattedValue;
            if (string.IsNullOrEmpty(text)) return;
            Size size = TextRenderer.MeasureText(text, view.Font);
            row.Height = Math.Max(size.Height + _rowMargins, row.Height);
        }
        private static void DataGridViewOnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1 || e.FormattedValue == null)
            {
                return;
            }
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All ^ DataGridViewPaintParts.ContentForeground);
            DataGridView view = sender as DataGridView;
            string textToDisplay = TrimTextToFit(string.Format("{0}", e.FormattedValue), (int)(e.CellBounds.Width * 0.96) - 3, e.CellBounds.Height - _rowMargins, view.Font);
            bool selected = view.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
            SolidBrush brush = new SolidBrush(selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor);
            e.Graphics.DrawString(textToDisplay, view.Font, brush, e.CellBounds.X + 1, e.CellBounds.Y + _rowMargins / 2);
            e.Handled = true;
        }
        private static string TrimTextToFit(string text, int contentWidth, int contentHeight, Font font)
        {
            Size size = TextRenderer.MeasureText(text, font);
            if (size.Width < contentWidth && size.Height < contentHeight)
            {
                return text;
            }
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while (i < text.Length)
            {
                sb.Append(text[i++]);
                size = TextRenderer.MeasureText(sb.ToString(), font);
                if (size.Width < contentWidth) continue;
                sb.Append("...");
                while (sb.Length > 3 && size.Width >= contentWidth)
                {
                    sb.Remove(sb.Length - 4, 1);
                    size = TextRenderer.MeasureText(sb.ToString(), font);
                }
                while (i < text.Length && text[i] != Environment.NewLine[0])
                {
                    i++;
                }
            }
            string res = sb.ToString();
            if (size.Height <= contentHeight)
            {
                return res;
            }
            string[] lines = res.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            i = lines.Length;
            while (i > 1 && size.Height > contentHeight)
            {
                res = string.Join(Environment.NewLine, lines, 0, --i);
                size = TextRenderer.MeasureText(res, font);
            }
            return res;
        }
    }
