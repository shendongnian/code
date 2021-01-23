    static bool IsColumns = true;
    List<Cell> Get(string input)
    {
        if (IsColumns) return table.getCol(input);
        else return table.getRow(input);
    }
