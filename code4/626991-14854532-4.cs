    public static void AddWithValue<T>(this IDbCommand command, this string name, T value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = pair.Key;
        parameter.Value = pair.Value;
        command.Parameters.Add(parameter);
    }
