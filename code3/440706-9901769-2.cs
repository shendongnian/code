    byte[] GetBytes(string resourceName)
    {
        var assembly = GetType().Assembly;
        var fullResourceName = string.Concat(assembly.GetName().Name, ".", resourceName);
        using (var stream = assembly.GetManifestResourceStream(fullResourceName))
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int) stream.Length);
            return buffer;
        }
    }
