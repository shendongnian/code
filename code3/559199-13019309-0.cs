    public DbType GetColumnDbType<T>(T column) where T: IComparable, IFormattable, IConvertible, struct // Note you can add struct constraint here as well.
    {
        if (!typeof(T).IsEnum) throw new ArgumentException("the object passed in must an enum type");
        var type = typeof(T);
        if (t == typeof(Enums.MemberColumn))
        {
           switch((Enums.MemberColumn)column)
           {
                  // case statements
           }
        }
        else if (t == typeof(Enums.OtherColumn))
        {
        }
        else
        {
           throw new NotSupportedException();
        }       
    }
