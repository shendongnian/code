    static bool IsExpandable(MemoryStream stream)
    {
        return (bool)typeof(MemoryStream)
            .GetField("_expandable", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .GetValue(stream);
    }
