    var bytes = File.ReadAllBytes(path);
    var ints = bytes.TakeWhile((b, i) => i % 2 == 0).Select((b, i) => BitConverter.ToInt16(bytes, i));
    if (bytes.Length % 2 == 1)
    {
        ints = ints.Union(new[] {BitConverter.ToInt16(new byte[] {bytes[bytes.Length - 1], 0}, 0)});
    }
    return ints.ToArray();
