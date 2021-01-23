		void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dv = sender as DataGridView;
			DataGridViewCellStyle rowStyle;// = dv.RowHeadersDefaultCellStyle;
			
			if (e.ColumnIndex == -1)
			{
				e.PaintBackground(e.CellBounds, true);
				e.Handled = true;
				if (/*I want to change this row */)
				{
					rowStyle = dv.Rows[e.RowIndex].HeaderCell.Style;
					rowStyle.BackColor = Color.Wheat;
					dv.Rows[e.RowIndex].HeaderCell.Style = rowStyle;
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
