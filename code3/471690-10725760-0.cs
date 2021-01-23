    public static IEnumerable<T> Ordenar<T>(IEnumerable<T> query, 
        string columna, string orden)
    {
        if (!(String.IsNullOrEmpty(orden) || String.IsNullOrEmpty(columna)))
        {
            FieldInfo orderField = typeof(T).GetField(columna);
            if (orden == "ASC")
                return query.OrderBy(x => orderField.GetValue(x));
            if (orden == "DESC")
                return query.OrderByDescending(x => orderField.GetValue(x));
        }
        return query;
    }
