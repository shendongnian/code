    private int[] vals = new int[81];
    public int this[int row, int column]
    {
        get { return vals[FindIndex(row, column)]; }
        set
        {
            vals[FindIndex(row, column)] = value;
        }
    }
 
    private int FindIndex(int row, int column)
    {
        return (((column - 1) * 9) + row - 1);
    }
