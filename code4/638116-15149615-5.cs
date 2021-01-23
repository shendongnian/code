    //given size and dimension
    //run this code once per different size, not on each check (probably move variable to some outer scope)
    Dictionary<string, int[]> winningSets = new Dictionary<string, int[]>();
    int[] indices = Enumerable.Range(0, dimension).ToArray(); //make array of 0 to (dimension - 1)
    for (int rowNum = 0; rowNum < size; ++rowNum) //0 based row index/num
    {
        int[] rowIndices = indices
            .Where(i => i / size == rowNum)
            .ToArray();
        winningSets.Add(String.Format("Row Number {0}", rowNum + 1), rowIndices); //use 1 based row index/num for display
    }
    for (int colNum = 0; colNum < size; ++colNum) //0 based row index/num
    {
        int[] colIndices = indices
            .Where(i => i % size == colNum)
            .ToArray();
        winningSets.Add(String.Format("Column Number {0}", colNum + 1), colIndices); //use 1 based column index/num for display
    }
    int[] diag1 = indices
        .Where(i => i % (size + 1) == 0)
        .ToArray();
    winningSets.Add("Diag TR to BL", diag1);
    int[] diag2 = indices
        .Where(i => i % (size - 1) == 0)
        .Skip(1) //skip 0 index
        .Take(size) //skip last index
        .ToArray(); 
    winningSets.Add("Diag TL to Br", diag2);
    //run this for each check
    foreach(KeyValuePair<string, int[]> winningSet in winningSets)
    {
        //Pseudo
        if (all of winningSet.Value indices are populated and same)
            return winningSet.Name; //Name of winning set, ex will not return multiple winning set which is possible in this game
        //this example does not show who won, but whoever had the last turn is the winner if one is found.
    }
