    private IEnumerable<OutputRow> BuildOutputTable(DataTable inputTable)
    {
        var tmp = from inputRow in inputTable.AsEnumerable()
                  select new { x = getProcessedRows(inputRow)};
        var outputRows = tmp.SelectMany(x=>x.x);
        return outputRows;
    }
    
    private IEnumerable<OutputRow> getProcessedRows(YourInputRowType inputRow)
    {
        List<OutputRow> ret = new List<OutputRow>()
        /* some logic here to generate the output rows for this input row */
        return ret;
    }
