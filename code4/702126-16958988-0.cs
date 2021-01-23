    public DataTable[] splitTable(DataTable mainDT,string columnName,int mod)
    {
        DataTable[] splitDT = new DataTable[11];
        for (int i=0;i<11;i++)
        {
            // Create a datatable with the same structure (schema) of the source table
            splitDT[i] = mainDT.Clone();
        }
        int splitINT;
        int tmp=0;
        foreach (DataRow row in mainDT.Rows)
        {              
           splitINT = row[columnName].GetHashCode();
           tmp = splitINT % mod;
           splitDT[tmp].ImportRow(row);
        }
        return splitDT;
    }
