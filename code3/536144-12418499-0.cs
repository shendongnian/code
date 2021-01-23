         DataTable targetTable = dsResults.Tables[0].Clone();
            var dt2Columns = dsResults.Tables[1].Columns.OfType<DataColumn>().Select(dc =>
                new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));
            targetTable.Columns.AddRange(dt2Columns.ToArray());
            var rowData =
                from row1 in dsResults.Tables[0].AsEnumerable()
                join row2 in dsResults.Tables[1].AsEnumerable()
                    on row1.Field<decimal>("RecordId") equals row2.Field<decimal>("RecordId2")
                select row1.ItemArray.Concat(row2.ItemArray).ToArray();
            foreach (object[] values in rowData)
                targetTable.Rows.Add(values);
