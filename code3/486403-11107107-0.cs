    public virtual T this[int row, int column]
    {
        get
        {
            RangeCheck(row, column);
            return At(row, column);
        }
        set
        {
            RangeCheck(row, column);
            At(row, column, value);
        }
    }
