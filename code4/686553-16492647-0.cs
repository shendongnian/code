    internal void InsertStrings(List<Tuple<string, string>> strings, Excel.Range selection, ComObjectManager com)
        {
            const int singleRowCell = 1;
            const int columnsToArea = 2;
            int firstRow = selection.Row;
            int column = selection.Column;
            for (int i = 0, j = firstRow; i < strings.Count; )
            {
                selection = com.Get<Excel.Range>(() => app.Cells[j, column]);
                var mergeArea = com.Get<Excel.Range>(() => selection.MergeArea);
                var mergeAreaRows = com.Get<Excel.Range>(() => mergeArea.Rows);
                var cells = com.Get<Excel.Range>(() => app.Cells);
                if (selection.MergeCells && mergeAreaRows.Count > singleRowCell)
                {
                    var roomNameCell = com.Get<Excel.Range>(() => cells[j, column]);
                    var areaCell = com.Get<Excel.Range>(() => cells[j, column + columnsToArea]);
                    roomNameCell.Value = strings[i].Item1;
                    areaCell.Value = strings[i].Item2;
  
                    ++i;
                }
                j += mergeAreaRows.Count;
            }
        }
