    /// <summary>
    /// Finds the duplicates inside of a DataGridView
    /// </summary>
    /// <param name="grid">The instance of the DataGridView</param>
    /// <param name="columnNamesToCompare">Collection of the Column.Name to compare</param>
    /// <returns>List of KeyValuePairs of the index and list of it's duplicates</returns>
    public IEnumerable<KeyValuePair<int, List<int>>> FindDuplicates(DataGridView grid, ICollection<string> columnNamesToCompare) {
            var dupesLog = new List<int>(); //represents rows that were marked as duplicates
            var locDupes = new List<int>(); //collector for the yield return
            for (int i = 0; i < grid.Rows.Count; i++) {
                if (dupesLog.Contains(i)) continue;
                locDupes.Clear();
                for (int j = 0; j < grid.Rows.Count; j++) {
                    if (j==i) continue;
                    foreach (string column in columnNamesToCompare) {
                        if (grid.Rows[i].Cells[column].Value.Equals(grid.Rows[j].Cells[column].Value) == false)
                            goto _next;
                    }
                    //if it got to here, means it is true
                    locDupes.Add(j);
                    dupesLog.Add(j);
                    _next:
                    continue;
                }
                if (locDupes.Count > 0)
                    yield return new KeyValuePair<int, List<int>>(i, locDupes);
            }
        }
