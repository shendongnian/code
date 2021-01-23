    public partial class Form1 : Form
    {
        private readonly int _rowMargins;
        public Form1()
        {
            InitializeComponent();
            int rowHeight = dataGridView1.Rows[0].Height;
            _rowMargins = rowHeight - dataGridView1.Font.Height;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewCell cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string text = string.Format("{0}", cell.FormattedValue);
            if (!string.IsNullOrEmpty(text))
            {
                Size size = TextRenderer.MeasureText(text, view.Font);
                view.Rows[e.RowIndex].Height = Math.Max(size.Height + _rowMargins, view.Rows[e.RowIndex].Height);
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                return;
            }
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All ^ DataGridViewPaintParts.ContentForeground);
            DataGridView view = sender as DataGridView;
            string textToDisplay = TrimTextToFit(string.Format("{0}", e.FormattedValue), (int) (e.CellBounds.Width * 0.96), view.Font);
            bool selected = view.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
            SolidBrush brush = new SolidBrush(selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor);
            
            e.Graphics.DrawString(textToDisplay, view.Font, brush, e.CellBounds.X, e.CellBounds.Y + _rowMargins / 2);
            
            e.Handled = true;
        }
        private static string TrimTextToFit(string text, int contentWidth, Font font)
        {
            Size size = TextRenderer.MeasureText(text, font);
            
            if (size.Width < contentWidth)
            {
                return text;
            }
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while (i < text.Length)
            {
                sb.Append(text[i++]);
                size = TextRenderer.MeasureText(sb.ToString(), font);
                if (size.Width <= contentWidth) continue;
                sb.Append("...");
                while (sb.Length > 3 && size.Width > contentWidth)
                {
                    sb.Remove(sb.Length - 4, 1);
                    size = TextRenderer.MeasureText(sb.ToString(), font);
                }
                
                while (i < text.Length && text[i] != Environment.NewLine[0])
                {
                    i++;
                }
            }
            return sb.ToString();
        }
    }
