    object[,] data = Range.Value2;
    // Create new Column in DataTable
    for (cCnt = 1; cCnt <= Range.Columns.Count; cCnt++)
    {
        textBox3.Text = cCnt.ToString();
            Column = new DataColumn();
            Column.DataType = System.Type.GetType("System.String");
            Column.ColumnName = cCnt.ToString();
            DT.Columns.Add(Column);
        // Create row for Data Table
        for (rCnt = 0; rCnt <= Range.Rows.Count; rCnt++)
        {
            textBox2.Text = rCnt.ToString();
            try
            {
                cellVal = (string)(data[rCnt, cCnt]);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                ConvertVal = (double)(data[rCnt, cCnt]);
                cellVal = ConvertVal.ToString();
            }
            // Add to the DataTable
            if (cCnt == 1)
            {
                Row = DT.NewRow();
                Row[cCnt.ToString()] = cellVal;
                DT.Rows.Add(Row);
            }
            else
            {
                Row = DT.Rows[rCnt];
                Row[cCnt.ToString()] = cellVal;
            }
        }
    } 
