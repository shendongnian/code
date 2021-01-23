		public static CheckBox AddHeaderCheckBox(this DataGridViewColumn column)
		{
			// Creating checkbox without panel
			CheckBox checkbox = new CheckBox();
			checkbox.Name = "chk" + column.Name;
			checkbox.Size = new Size(15, 15);
			checkbox.BackColor = Color.Transparent;
			checkbox.Enabled = !column.ReadOnly;
			// Reset properties
			checkbox.Padding = new Padding(0);
			checkbox.Margin = new Padding(0);
			checkbox.Text = "";
			var changedByUser = true;
			var dgv = column.DataGridView;
			BindingSource bindingSource = null;
			checkbox.CheckedChanged += (s, e) =>
			{
				if (changedByUser)
				{
					try
					{
						changedByUser = false;
						var sortedColumn = dgv.SortedColumn;
						var sortOrder = dgv.SortOrder;
						var sortMode = dgv.Columns[column.Name].SortMode;
						var isColumnSorted = sortedColumn != null && sortedColumn.Name.Equals(column.Name);
						if (isColumnSorted)
						{
							dgv.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
							if (bindingSource != null)
								bindingSource.Sort = "";
						}
						foreach (DataGridViewRow row in dgv.Rows)
							row.Cells[column.Name].Value = checkbox.Checked;
						if (isColumnSorted)
						{
							dgv.Columns[column.Name].SortMode = sortMode;
							if (sortOrder != System.Windows.Forms.SortOrder.None)
								dgv.Sort(sortedColumn, sortOrder == System.Windows.Forms.SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
						}
					}
					finally
					{
						changedByUser = true;
					}
				}
			};
			// Add checkbox to datagrid cell
			dgv.Controls.Add(checkbox);
			Action onColResize = () =>
			{
				var colCheck = dgv.Columns[column.Name];
				int colLeft = (dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0) - dgv.HorizontalScrollingOffset;
				foreach (DataGridViewColumn col in dgv.Columns)
				{
					if (col.DisplayIndex == colCheck.DisplayIndex) break;
					colLeft += col.Width;
				}
				checkbox.Location = new Point(
					colLeft + colCheck.Width / 2 - checkbox.Width / 2,
					dgv.ColumnHeadersHeight / 2 - checkbox.Height / 2
				);
			};
			dgv.ColumnWidthChanged += (s, e) => onColResize();
			dgv.Scroll += (s, e) => onColResize();
			dgv.Resize += (s, e) => onColResize();
			Action<object> onDataChanged = (e) =>
			{
				if (!changedByUser) return;
				if (e is DataColumnChangeEventArgs)
				{
					if (!((DataColumnChangeEventArgs)e).Column.ColumnName.Equals(column.Name))
						return;
				}
				else if (e is ListChangedEventArgs)
				{
					var prop = ((ListChangedEventArgs)e).PropertyDescriptor;
					if (prop != null && !prop.Name.Equals(column.Name))
						return;
				}
				bool allAreTrue = true;
				foreach (DataGridViewRow row in dgv.Rows)
				{
					var val = row.Cells[column.Name].Value;
					if (val == null || val.ToString() != "True")
					{
						allAreTrue = false;
						break;
					}
				}
				try
				{
					changedByUser = false;
					checkbox.Checked = allAreTrue;
				}
				finally
				{
					changedByUser = true;
				}
			};
			if (dgv.DataSource is BindingSource)
			{
				bindingSource = (BindingSource)dgv.DataSource;
				bindingSource.ListChanged += (s, e) => onDataChanged(e);
			}
			else if (dgv.DataSource is DataSet)
				((DataSet)dgv.DataSource).Tables[dgv.DataMember].ColumnChanged += (s, e) => onDataChanged(e);
			else if (dgv.DataSource is DataTable)
				((DataTable)dgv.DataSource).ColumnChanged += (s, e) => onDataChanged(e);
			return checkbox;
		}
