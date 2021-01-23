    using (var writer = new StreamWriter("foo.txt"))
    {
        writer.Write(someString);
        writer.Write(someDouble);
        writer.WriteLine();
    }
