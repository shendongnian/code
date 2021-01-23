    using (var stream = File.OpenRead("path_to_file"))
    {
        stream.Position = Bom.GetCursor(stream);
    }
    public static class Bom
    {
            public static int GetCursor(Stream stream)
            {
                // UTF-32, big-endian
                if (IsMatch(stream, new byte[] {0x00, 0x00, 0xFE, 0xFF}))
                    return 4;
                // UTF-32, little-endian
                if (IsMatch(stream, new byte[] { 0xFF, 0xFE, 0x00, 0x00 }))
                    return 4;
                // UTF-16, big-endian
                if (IsMatch(stream, new byte[] { 0xFE, 0xFF }))
                    return 2;
                // UTF-16, little-endian
                if (IsMatch(stream, new byte[] { 0xFF, 0xFE }))
                    return 2;
                // UTF-8
                if (IsMatch(stream, new byte[] { 0xEF, 0xBB, 0xBF }))
                    return 3;
                return 0;
            }
            private static bool IsMatch(Stream stream, byte[] match)
            {
                stream.Position = 0;
                var buffer = new byte[match.Length];
                stream.Read(buffer, 0, buffer.Length);
                return !buffer.Where((t, i) => t != match[i]).Any();
            }
        }
