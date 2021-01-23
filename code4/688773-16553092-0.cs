    for (int i = 0; i < GlobalData.CellH.Length; i++)
    {
        if (GlobalData.CellH[i] == null)
        {
        }
        else if (GlobalData.CellH[i].Contains("M"))
        {
            GlobalData.TotalBoys++;
        }
        else if (GlobalData.CellH[i].Contains("F"))
        {
            GlobalData.TotalGirls++;
        }
    }
