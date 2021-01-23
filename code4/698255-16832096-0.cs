    var commonColumns = dt1.Columns.OfType<DataColumn>().Intersect(dt2.Columns.OfType<DataColumn>(), new DataColumnComparer());
            DataTable result = new DataTable();
            dt1.PrimaryKey = commonColumns.ToArray();
            result.Merge(dt1, false, MissingSchemaAction.AddWithKey);
            result.Merge(dt2, false, MissingSchemaAction.AddWithKey);
