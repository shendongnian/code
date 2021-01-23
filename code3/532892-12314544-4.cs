    var TblData = new DataTable();
    TblData.Columns.Add("FeeID", typeof(int));
    TblData.Columns.Add("Amount", typeof(int));
    TblData.Columns.Add("FeeItem", typeof(string));
    TblData.Columns.Add("Type", typeof(char));
    for (int i = 0; i < 1000000; i++)
    {
        TblData.Rows.Add(9, 8500, "Admission Free", 'T');
        TblData.Rows.Add(9, 950, "Annual Fee", 'T');
        TblData.Rows.Add(9, 150, "Application Free", 'T');
        TblData.Rows.Add(9, 850, "Boy's Uniform", DBNull.Value);
        TblData.Rows.Add(9, 50, DBNull.Value, 'R');
        TblData.Rows.Add(10, 7500, "Admission Free", 'T');
        TblData.Rows.Add(11, 900, "Annual Fee", 'T');
        TblData.Rows.Add(11, 150, "Application Free", 'T');
        TblData.Rows.Add(11, 850, DBNull.Value, 'T');
        TblData.Rows.Add(11, 50, "Computer Free", 'R');
    }
    int rowCount = TblData.Rows.Count; // 10000000
