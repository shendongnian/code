        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                Color c1 = Color.FromArgb(255, 54, 54, 54);
                Color c2 = Color.FromArgb(255, 62, 62, 62);
                Color c3 = Color.FromArgb(255, 98, 98, 98);
                LinearGradientBrush br = new LinearGradientBrush(e.CellBounds, c1, c3, 90, true);
                ColorBlend cb = new ColorBlend();
                cb.Positions = new[] { 0, (float)0.5, 1 };
                cb.Colors = new[] { c1, c2, c3 };
                br.InterpolationColors = cb;
                e.Graphics.FillRectangle(br, e.CellBounds);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }
