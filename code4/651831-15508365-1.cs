    private static readonly HashSet<Type> ValidTypes = new HashSet<Type>
    {
        typeof(sbyte), typeof(byte), /* etc */
    };
    public static ConvertToDouble(object x)
    {
        if (x == null)
        {
            throw new ArgumentNullException("x");
        }
        if (!ValidTypes.Contains(x.GetType())
        {
            throw new ArgumentException("...");
        }
        return Convert.ChangeType(x, typeof(double));
    }
