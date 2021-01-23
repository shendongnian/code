    // Collection to hold your matrices
    List<List<int>> myMatrices = new List<List<int>>();
    // Iterate through all rows and columns
    for (int i = 0; i <= 60; i = i + 10)
    {
        var matrix = new List<int>();
        for (int j = 1; j <= 6; j++)
        {
            // Dynamically search parent control for child textboxes
            var txt = pnlMain.FindControl(string.Format("{0}{1}", i == 0 ? "x" : "a", i + j)) as TextBox;
            if (txt != null)
            {
                int value = 0;
                int.TryParse(int.Parse(txt), out value);
                matrix.Add(value);
            }
        }
        myMatrices.Add(matrix);
     }      
