    void Do(object value)
    {
        if (value.GetType().IsArray)
        {
           string[] strings = ((object[]) value).Select(obj => Convert.ToString(obj)).ToArray();
        }
    }
