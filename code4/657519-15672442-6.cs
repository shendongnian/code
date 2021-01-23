    // using List<List<Button>>
    var buttonLists = new List<List<Button>>();
    for (int r = 0; r < row; r++)
    { 
        var buttonRow = new List<Button>();
        buttonLists.Add(buttonRow);    
        for (int c = 0; c < col; c++)
        {
            buttonRow.Add(new Button());
        }
    }
    // using Button[][]
   
    var buttonArrays = new Button[row][];
    for (int r = 0; r < row; r++)
    {
        buttonArrays[r] = new Button[col];
        for (int c = 0; c < col; c++)
        {
            buttonArrays[r][c] = new Button();
        }
    }
