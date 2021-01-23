            var dataTable = new DataTable(); // your input DataTable here!
            var pivotedDataTable = new DataTable(); //the pivoted result
            var firstColumnName = "Year";
            var pivotColumnName = "Codes";
            pivotedDataTable.Columns.Add(firstColumnName);
            pivotedDataTable.Columns.AddRange(
                dataTable.Rows.Cast<DataRow>().Select(x => new DataColumn(x[pivotColumnName].ToString())).ToArray());
            for (var index = 1; index < dataTable.Columns.Count; index++)
            {
                pivotedDataTable.Rows.Add(
                    new List<object> { dataTable.Columns[index].ColumnName }.Concat(
                        dataTable.Rows.Cast<DataRow>().Select(x => x[dataTable.Columns[index].ColumnName])).ToArray());
            }
