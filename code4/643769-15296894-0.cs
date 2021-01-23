        private DataTable GetDataTableFromDictionaries<T>(List<Dictionary<string, T>> list)
        {
            DataTable dataTable = new DataTable();
            if (list == null || !list.Any()) return dataTable;
            foreach (var column in list.First().Select(c => new DataColumn(c.Key, typeof(T))))
            {
                dataTable.Columns.Add(column);
            }
            foreach (var row in list.Select(
                r =>
                    {
                        var dataRow = dataTable.NewRow();
                        r.ToList().ForEach(c => dataRow.SetField(c.Key, c.Value));
                        return dataRow;
                    }))
            {
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
