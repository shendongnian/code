    var validRows = new List<int>();
    for (int y = 0; y < mat.Length; y++)
    {
        bool isRowValid = true;
        for (int x = 0; x < arr.Length; x++)
        {
            if (mat[y, x] != 'd' && mat[y, x] != arr[x])
            {
                isRowValid = false;
                break;
            }
        }
        if (isRowValid)
        {
            validRows.Add(y);
        }
    }
    foreach (var y in validRows)
    {
        Console.WriteLine("Row {0} is valid", y);
    }
