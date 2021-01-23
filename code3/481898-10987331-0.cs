    public static int StringToInt(string numStr, int defValue)
    {
        int num;
        if (!Int32.TryParse(numStr, out num)) { return defValue; }
        return num;
    }
