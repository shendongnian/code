    	private void btnNewImage_Click(object sender, EventArgs e)
		{
			if (imgCount == 0)
				tlp.Controls.Add(new Button { Text = "Image " + ++imgCount, Dock = DockStyle.Fill }, 0, 0);
			else
			{
				// tlp is the TableLayoutPanel which is docked as Dock.Fill
				if (tlp.RowCount == tlp.ColumnCount)
				{
					tlp.ColumnCount++;
					for (int i = 0; i < tlp.RowCount; i++)
						tlp.Controls.Add(new Button { Text = "Image " + ++imgCount, Dock = DockStyle.Fill }, tlp.ColumnCount - 1, i);
					tlp.ColumnStyles.Clear();
					for (int i = 0; i < tlp.ColumnCount; i++)
						tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)100.0 / (float)tlp.ColumnCount));
				}
				else
				{
					tlp.RowCount++;
					for (int i = 0; i < tlp.ColumnCount; i++)
						tlp.Controls.Add(new Button { Text = "Image " + ++imgCount, Dock = DockStyle.Fill }, i, tlp.RowCount - 1);
					tlp.RowStyles.Clear();
					for (int i = 0; i < tlp.RowCount; i++)
						tlp.RowStyles.Add(new RowStyle(SizeType.Percent, (float)100.0 / (float)tlp.RowCount));
				}
			}
