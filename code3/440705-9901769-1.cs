    byte[] GetBytes()
    {
        var assembly = GetType().Assembly;
        using (var stream = assembly.GetManifestResourceStream("ClassLibrary1.Foo.jpg"))
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int) stream.Length);
            return buffer;
        }
    }
