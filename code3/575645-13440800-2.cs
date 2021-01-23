    int n = 5;
    for (int row = 1; row <=n; row++) 
    {
        string rowContent = String.Empty;
        for (int col = 1;col <=n; col++)
        {
            rowContent += "# ";
        }
        Console.WriteLine(rowContent);
    }
