    void GeneralizedFunction<T>(string aStringA, string aStringB, Func<T, string> stringGetter)
    {
        A result1 = Deserialize<A>(stringGetter(aStringA));
        B result2 = Deserialize<B>(stringGetter(aStringB));
    }
    void Example(string serializedA, string serializedB, string pathToA, string pathToB, FileInfo a, FileInfo b)
    {
        GeneralizedFunction(serializedA, serializedB, s => s);
        GeneralizedFunction(pathToA, pathToB, File.ReadAllText);
        GeneralizedFunction(a, b, fi => File.ReadAllText(fi.FullName));
    }
