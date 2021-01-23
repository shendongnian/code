    public int Compare(Guid x, Guid y)
    {
        var xBytes = x.ToByteArray();
        var yBytes = y.ToByteArray();
        int result = 0;
        for (int i = 0; i < 4; i++)
        {
            var result = xBytes[i].CompareTo(yBytes[i]);
            if (result != 0)
            {
                break;
            }
        }
        return result;
    }
