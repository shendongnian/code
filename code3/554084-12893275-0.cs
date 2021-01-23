    var result = new List<string>();
    var properties = lastChange.GetType().GetProperties(); // both rows are of the same type
    foreach(var propInfo in properties)
    {
        var obj1 = propInfo.GetValue(lastChange, null);
        var obj2 = propInfo.GetValue(previousChange, null);
        if(obj1 != obj2)
            result.Add(propInfo.Name);
    }
    return result;
    }
