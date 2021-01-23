    int oi, ii;
    for (oi = 0; oi <= cells.GetUpperBound(0); ++oi)
    {
        for (ii = 0; ii <= cells.GetUpperBound(1); ++ii)
        {
            System.Diagnostics.Debug.WriteLine(
                "Checking: " + oi + "," + ii + " : " + cells[oi, ii].ToString()
            );
        }
    }
