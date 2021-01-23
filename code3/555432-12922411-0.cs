    int fixedWidth = 0;
			int countDynamic = 0;
			for (int i = 0; i < listView1.Columns.Count; i++)
			{
				ColumnHeader header = listView1.Columns[i];
				if (header.Tag != null && header.Tag.ToString() == "fixed")
					fixedWidth += header.Width;
				else
					countDynamic++;
			}
			for (int i = 0; i < listView1.Columns.Count; i++)
			{
				ColumnHeader header = listView1.Columns[i];
				if (header.Tag == null)
					header.Width = ((listView1.Width - fixedWidth) / countDynamic);
			}
