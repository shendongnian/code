    public static string ToMoney(this object o)
    {
        // note: this is obviously only good for USD
        return string.Forma("{0:C}", o).Replace("($","$(");
    }
