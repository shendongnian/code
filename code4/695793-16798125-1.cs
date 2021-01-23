    Random rand = new Random();
    // Mark every row as not selected yet.
    int[] nonSelectedRows = new int[dt.Rows.Count];
    for(int i = 0; i < dt.Rows.Count; i++)
        nonSelectedRows[i] = 1;
    int numSelected = 0;
    int numLeft = dt.Rows.Count;
    int targetNum = dt.Rows.Count * errPercentage;
    while(numSelected < targetNum)
    {
        for (int row = 0; row < dt.Rows.Count; row++)
        {
           // Each record has a 1/numleft chance of getting selected.
           boolean isSelected = rand.Next(numLeft) == 0; 
           // Check to make sure it hasn't already been selected.
           if(isSelected && nonSelectedRows[row] > 0)
           {
               dtRandomRows.ImportRow(dt.Rows[row]);
               nonSelectedRows[row] = -1; // Mark this row as selected.
               numSelected++;
               numLeft--;
           }
   
           // We've already found enough to match our targetNum.
           if(numSelected >= targetNum)
               break;
        }
    }
