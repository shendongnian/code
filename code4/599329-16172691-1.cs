    public partial class Form1 : Form
    {
        private int _rowIndex = 1;
        private readonly int _rowMargins;
        public Form1()
        {
            InitializeComponent();
            int rowHeight = dataGridView1.Rows[0].Height;
            Size size = TextRenderer.MeasureText("A", dataGridView1.Font);
            _rowMargins = rowHeight - size.Height;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewCell cell = view.Rows[e.RowIndex].Cells[0];
            if (cell.Value == null)
            {
                cell.Value = _rowIndex++;
            }
            cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string text = string.Format("{0}", cell.Value);
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace(".", "." + Environment.NewLine);
                cell.Value = text;
                Size size = TextRenderer.MeasureText(text, view.Font);
                view.Rows[e.RowIndex].Height = size.Height + _rowMargins;
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != 1 || e.RowIndex == -1)
            {
                return;
            }
            DataGridView view = sender as DataGridView;
            //draw all but content
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All ^ DataGridViewPaintParts.ContentForeground);
            
            string text = string.Format("{0}", e.FormattedValue);
            Size size = TextRenderer.MeasureText(text, view.Font);
            //Padding padding = view.Columns[e.ColumnIndex].DefaultCellStyle.Padding;
            //int contentWidth = e.CellBounds.Width - padding.Left - padding.Right;
            int horizontalPadding = 20; //TODO: find the real value
            int contentWidth = e.CellBounds.Width - horizontalPadding;
            if (size.Width > contentWidth)
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (i < text.Length)
                {
                    sb.Append(text[i++]);
                    size = TextRenderer.MeasureText(sb.ToString(), view.Font);
                    if (size.Width <= contentWidth) continue;
                    sb.Append("...");
                    while (size.Width > contentWidth)
                    {
                        sb.Remove(sb.Length - 4, 1);
                        size = TextRenderer.MeasureText(sb.ToString(), view.Font);
                    }
                    while (i < text.Length && text[i] != Environment.NewLine[0])
                    {
                        i++;
                    }
                }
                text = sb.ToString();
            }
            e.Graphics.DrawString(text, view.Font, new SolidBrush(view.ForeColor), e.CellBounds.X + horizontalPadding / 4, e.CellBounds.Y + _rowMargins / 2);
            e.Handled = true;
        }
    }
