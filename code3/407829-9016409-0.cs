    DataSet cyclesDataSet = new DataSet("Cycles");
    someclass.CycleComplete(cyclesDataSet, "C1");
    .
    .
    .
    public void CycleComplete(DataSet dataset, String cycleId)
    {
        var cycleTable = dataset.Tables.Add("cycleId");
        // Manipulate table here.
    }
