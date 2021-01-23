    public static CheckBox AddDataGridViewHeaderCheckBox(DataGridViewColumn column)
    		{
    			// Creating checkbox without panel
    			CheckBox checkbox = new CheckBox();
    			checkbox.Name = "chk" + column.Name;
    			checkbox.Size = new System.Drawing.Size(15, 15);
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
    							if (sortOrder != SortOrder.None)
    								dgv.Sort(sortedColumn, sortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
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
    
    			Action<DataColumnChangeEventArgs> onDataChanged = (e) =>
    			 {
    				 if (!changedByUser
    					|| (e != null && !e.Column.ColumnName.Equals(column.Name))) return;
    
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
    
    			object dataSource;
    			string dataMember;
    			if (dgv.DataSource is BindingSource)
    			{
    				bindingSource = (BindingSource)dgv.DataSource;
    				bindingSource.CurrentChanged += (s, e) => onDataChanged(null);
    				dataSource = bindingSource.DataSource;
    				dataMember = bindingSource.DataMember;
    			}
    			else
    			{
    				dataSource = dgv.DataSource;
    				dataMember = dgv.DataMember;
    			}
    
    			if (dataSource is DataSet)
    				((DataSet)dataSource).Tables[dataMember].ColumnChanged += (s, e) => onDataChanged(e);
    			else if (dataSource is DataTable)
    				((DataTable)dataSource).ColumnChanged += (s, e) => onDataChanged(e);
    
    			return checkbox;
    		}
