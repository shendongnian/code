    public static bool MyCompare<T>(T obj1, T obj2)
    {
        bool bp = obj1.GetType()
            .GetProperties()
            .All(p=>p.GetValue(obj1).Equals(obj2.GetType().GetProperty(p.Name).GetValue(obj2)));
        bool bf = obj1.GetType()
            .GetFields()
            .All(f => f.GetValue(obj1).Equals(obj2.GetType().GetField(f.Name).GetValue(obj2)));
        return bp && bf;
    }
