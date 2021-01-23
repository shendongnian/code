		void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dv = sender as DataGridView;
			DataGridViewCellStyle rowStyle;// = dv.RowHeadersDefaultCellStyle;
			rowStyle = dv.Rows[3].HeaderCell.Style;
			if (e.ColumnIndex == -1)
			{
				e.PaintBackground(e.CellBounds, true);
				e.Handled = true;
				rowStyle.BackColor = Color.Wheat;
				dv.Rows[3].HeaderCell.Style = rowStyle;
				if (e.RowIndex == 3)
				{
					using (Brush gridBrush = new SolidBrush(Color.Wheat))
					{
						using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
						{
							using (Pen gridLinePen = new Pen(gridBrush))
							{
								// Clear cell 
								e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
								//Bottom line drawing
								e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
								// here you force paint of content
								e.PaintContent(e.ClipBounds);
								e.Handled = true;
							}
						}
					}
				}
			}
		}
