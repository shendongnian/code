    if (dgv_Cuotas.Columns[e.ColumnIndex].Name == "Seleccionar" && Convert.ToDecimal(dgv_Cuotas.Rows[e.RowIndex].Cells["Restante"].Value) == 0)
                {
                    Color c1 = Color.FromArgb(255, 113, 255, 0);
                    Color c2 = Color.FromArgb(255, 2, 143, 17);
                    LinearGradientBrush br = new LinearGradientBrush(e.CellBounds, c1, c2, 90, true);
                    ColorBlend cb = new ColorBlend();
                    cb.Positions = new[] { 0, (float)1 };
                    cb.Colors = new[] { c1, c2 };
                    br.InterpolationColors = cb;
                    Rectangle rect = new Rectangle(e.CellBounds.Location.X + 4, e.CellBounds.Location.Y + 4, 13, 13);
                    e.Graphics.FillRectangle(br, rect);
                    e.PaintContent(rect);
                    e.Handled = true;
                }
