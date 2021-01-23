    public decimal getProp(string str)
    {
        int obIndex = str.IndexOf("["); // get the index of the open bracket
        int cbIndex = str.IndexOf("]"); // get the index of the close bracket
        decimal d = decimal.Parse(str.Substring(obIndex + 1, cbIndex - obIndex - 2)); // this extracts the numerical part and converts it to a decimal (assumes a % before the ])
        return Math.Round(d); // return the number rounded to the nearest integer
    }
