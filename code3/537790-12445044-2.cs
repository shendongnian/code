    public static object DbNullIfNull(this object obj)
    {
        return obj != null ? obj : DBNull.Value;
    }
    command.Parameters.AddWithValue("@name", value.DbNullIfNull());
