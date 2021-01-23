    foreach (var str in GlobalData.CellH)
    {
        switch (str)
        {
            case "M":
                GlobalData.TotalBoys++;
                break;
            case "F":
                GlobalData.TotalGirls++;
                break;
            default:    // includes case where str == null
                // ...
                break;
        }
    }
