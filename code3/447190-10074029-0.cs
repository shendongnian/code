    if (value != null)
    {
        if (value.GetType().IsGenericType == true
            && value.GetType().GetGenericArguments().Length >= 0)
        {
            IList _valuesList = null;
    
            if (value.GetType().GetGenericArguments()[0].ToString().ToLower().Contains("int"))
            {
                _valuesList = value as List<int>;
            }
            else if (value.GetType().GetGenericArguments()[0].ToString().ToLower().Contains("decimal"))
            {
                _valuesList = value as List<decimal>;
            }
            else if (value.GetType().GetGenericArguments()[0].ToString().ToLower().Contains("double"))
            {
                _valuesList = value as List<double>;
            }
            else if (value.GetType().GetGenericArguments()[0].ToString().ToLower().Contains("string"))
            {
                _valuesList = value as List<string>;
            }
        }
    }
