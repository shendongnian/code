    public string StringOrNull (object value)
    {
        if (value != null){
           return value.ToString();
        }
        return null;
    }
