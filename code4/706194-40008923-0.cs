        private void ColumnDisplayOrder(string columnList, DataGridView gridView)
        {
            var columnListArray = columnList.Split(',');
            for (var i = 0; i < columnListArray.Length; i++)
            {
                var gridViewColumn = gridView.Columns[columnListArray[i].Trim()];
                if (gridViewColumn != null)
                    gridViewColumn.DisplayIndex = i;
            }
        }
