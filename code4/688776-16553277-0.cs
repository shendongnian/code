    // If necessary, first check if GlobalData == null
    // and if GlobalData.CellH == null. Then:
    foreach (var str in GlobalData.CellH)
    {
        if (str == null)
        {
            // ...
        }
        else if (str.Contains("M"))
        {
            GlobalData.TotalBoys++;
        }
        else if (str.Contains("F"))
        {
            GlobalData.TotalGirls++;
        }
    }
