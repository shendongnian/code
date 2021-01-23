    public CONTENT GetRowType(string pk) 
    {
        int temp = Convert.ToInt32(pk.Substring(2, 2));
        if (Enum.IsDefined(typeof(CONTENT), temp)) 
        { 
            return (CONTENT)temp;
        }
        else throw new IndexOutOfRangeException();
    }
