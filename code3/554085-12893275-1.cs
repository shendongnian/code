    private IEnumerable<Tuple<string, object, object>> GetChangesBetweenRows(History row1, History row2)
    {
        var result = new List<Tuple<string, object, object>>();
        var properties = lastChange.GetType().GetProperties(); // both rows are of the same type
        foreach(var propInfo in properties)
        {
            var obj1 = propInfo.GetValue(lastChange, null);
            var obj2 = propInfo.GetValue(previousChange, null);
            if(obj1 != obj2)
                result.Add(Tuple.Create(propInfo.Name, obj1, obj2));
        }
        return result;
    }
