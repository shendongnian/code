    public static BusinessObject Clone(this BusinessObject obj)
    {
        BusinessObject newObj = (BusinessObject)
              Activator.CreateInstance(obj.GetType());
        var props = newObj.Properties;
        foreach (var p in props)
            newObj.Properties[p.Name].SetValue(newObj,
              obj.Properties[p.Name].GetValue(obj));
        return newObj;
    }
