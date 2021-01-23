    public DataRow SubRow(DataTable resultsTable, string subHead, string subHeader, string subHeadValue)
    {
        DataRow shRow = resultsTable.NewRow();
        shRow["a"] = subHead;
        shRow["b"] = subHeader;
        shRow["c"] = subHeadValue;
        return shRow;
    }
