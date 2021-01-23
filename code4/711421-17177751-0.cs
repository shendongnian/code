    public static bool SameCompare<T, T2>(T manuallyCreated, T2 generated){
        var propertiesForGenerated = typeof(T2).GetProperties();
        int compareValue = 0;
        foreach (var prop in propertiesForGenerated) {
            var firstProperty = typeof(T).GetProperty(prop.Name);
            var valFirst = firstProperty.GetValue(manuallyCreated, null) as IComparable;
            var valSecond = prop.GetValue(generated, null) as IComparable;
            ...
        }
    }
