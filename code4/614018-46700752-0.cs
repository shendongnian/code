    public static string ToPrettySize(this float Size)
    {
        return ConvertToPrettySize(Size, 0);
    }
    public static string ToPrettySize(this int Size)
    {
        return ConvertToPrettySize(Size, 0);
    }
    private static string ConvertToPrettySize(float Size, int R)
    {
        float F = Size / 1024f;
        if (F < 1)
        {
            switch (R)
            {
                case 0:
                    return string.Format("{0:0.00} byte", Size);
                case 1:
                    return string.Format("{0:0.00} kb", Size);
                case 2:
                    return string.Format("{0:0.00} mb", Size);
                case 3:
                    return string.Format("{0:0.00} gb", Size);
            }
        }
        return ConvertToPrettySize(F, ++R);
    }
}`
