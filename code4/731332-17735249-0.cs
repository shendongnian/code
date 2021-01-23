    IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> list, T divider)
    {
        var temp = new List<T>();
        foreach (var item in list)
        {
            if (!item.Equals(divider))
            {
                temp.Add(item);
            }
            else
            {
                yield return temp;
                temp = new List<T>();
            }
        }
        if(temp.Count>0) yield return temp;
    }
