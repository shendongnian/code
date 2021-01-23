    public string TestBadal<T>(
            IList<T> list,
            Func<T, string> stringSelector)
    {
        var result = new StringBuilder();
        for(var i = 0; i < list.Count; i++)
        {
            result.AppendLine(stringSelector(list[i])
        }
        
        return result.ToString();
    }
