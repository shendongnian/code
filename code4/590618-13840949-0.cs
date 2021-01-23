    if ((value !=null) && value.GetType().IsGenericType &&
           value.GetType().GetGenericTypeDefinition() == typeof (Dictionary<,>))
    {
       return DictionaryToString(castValue);
    }
    else
    {
      return value.ToString();
    }
