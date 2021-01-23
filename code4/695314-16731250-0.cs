    public static List<T> deepCopyList<T>(List<T> src)
        where T : new()
    {
        // I can now call new, like so
        var value = new T();
    }
