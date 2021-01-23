    static object[][] ConvertToObjectArray<T>(IList<T> objects)
    {
        var fields = (from fieldInfo in typeof(T).GetFields(
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                      orderby fieldInfo.Name
                      select fieldInfo).ToArray();
        object[][] table = new object[objects.Count][];
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = (from fieldInfo in fields
                        select fieldInfo.GetValue(objects[i])).ToArray();
        }
        return table;
    }
