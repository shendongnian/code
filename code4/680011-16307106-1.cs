    public static bool IsInt(string value)
    {
        int num;
        return int.TryParse(value, out num);
    }
