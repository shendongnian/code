    public static bool operator true(ColumnOperation x)
    {
        ...
    }
    public static bool operator false(ColumnOperation x)
    {
        ...
    }
    
    public static ColumnOperation operator &(ColumnOperation lhs, ColumnOperation rhs)
    {
        return new ColumnBooleanOperation(lhs, rhs, ExpressionType.And);
    }
