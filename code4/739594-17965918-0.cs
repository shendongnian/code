    private DataTable GetNColumnsFromDataTable(DataTable objSource, int outputCols)
    {
        DataTable objOutput = objSource.Copy();
    
        if (outputCols > 0 && outputCols < objSource.Columns.Count)
        {
            while (outputCols < objOutput.Columns.Count)
            {
                objOutput.Columns.RemoveAt(objOutput.Columns.Count - 1);
            }
        }
    
        return objOutput;
    }
