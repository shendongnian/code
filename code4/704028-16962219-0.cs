    public static void AddParameters(this SqlCommand command, object parameters)
    {
        foreach (var propertyInfo in parameters.GetType().GetProperties())
        {
            object propertyValue = propertyInfo.GetValue(parameters, null);
            command.Parameters.AddWithValue("@" + propertyInfo.Name, propertyValue);
        }
    }
