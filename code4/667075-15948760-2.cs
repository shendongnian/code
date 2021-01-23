    Property(
        x => x.Dollars,
        m => m.MapMoney()
     );
    public static void MapMoney(this IPropertyMapper mapper)
    {
        m.Precision(9);
        m.Scale(6);
    }
