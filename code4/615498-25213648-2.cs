    public int ColumnNameParse(string cellReference)
    {
        var value = cellReference.TrimEnd("1234567890".ToCharArray());
        // assumes value.Length is [1,3]
        // assumes value is uppercase
        var digits = value.PadLeft(3).Select(x => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(x));
        return digits.Aggregate(0, (current, index) => (current * 26) + (index + 1));
    }
