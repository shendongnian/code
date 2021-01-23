       for (var i = 0; i < dr2.FieldCount; i++)
        {
            _dataTable.Columns.Add("" + dr2.GetName(i) + "", typeof(string));
            _dataTable.Rows.Add("" + dr2.GetValue(i) + "");
        }
