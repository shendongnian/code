    public static int? TryGetInt(this string item)
    {
        int i;
        bool success = int.TryParse(item, out i);
        return success ? (int?)i : (int?)null;
    }
