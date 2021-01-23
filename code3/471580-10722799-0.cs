       DataGridViewCheckBoxColumn selectedColumn = new DataGridViewCheckBoxColumn();
       selectedColumn.Name = "Selected";
       selectedColumn.HeaderText = "Attach";
       selectedColumn.ReadOnly = false;
       this.uiDocumentDataGrid.Columns.Insert(0,selectedColumn);
       uiDocumentDataGrid.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(uiDocumentDataGrid_CellToolTipTextNeeded);
