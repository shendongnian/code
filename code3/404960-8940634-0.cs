    private string GetBitMask(params bool[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
        {
            sb.Append(value ? "1" : "0");
        }
        return sb.ToString();
    }
