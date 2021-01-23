    try
    {
        dataSet.Merge(anotherDataSet);
    }
    catch (ConstraintException)
    {
        foreach (DataTable table in dataSet.Tables)
        {
            DataRow[] rowErrors = table.GetErrors();
            System.Diagnostics.Debug.WriteLine(table.TableName + " Errors:" + rowErrors.Length);
            for (int i = 0; i < rowErrors.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine(rowErrors[i].RowError);
                foreach (DataColumn col in rowErrors[i].GetColumnsInError())
                {
                    System.Diagnostics.Debug.WriteLine(col.ColumnName + ":" + rowErrors[i].GetColumnError(col));
                }
            }
        }
    }
