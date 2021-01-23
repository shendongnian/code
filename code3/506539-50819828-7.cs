    public static class UTF8FileLastLineReader
    {
        // attempt to fill buffer with bytes equal to buffer.Length, throws if not enough bytes available
        private static byte[] ReadExactly(this System.IO.Stream stream, byte[] buffer)
        {
            int offset = 0;
            while (offset < buffer.Length)
            {
                int read = stream.Read(buffer, offset, buffer.Length - offset);
                if (read == 0)
                    throw new System.IO.EndOfStreamException();
                offset += read;
            }
            System.Diagnostics.Debug.Assert(offset == buffer.Length);
            return buffer;
        }
        // file at path must be utf8 encoded
        public static string ReadLastLineFromUTF8EncodedFile(string path)
        {
            using (System.IO.Stream fs = System.IO.File.OpenRead(path))
            {
                int b;
                fs.Position = fs.Length;
                while (fs.Position > 0)
                {
                    fs.Position--;
                    b = fs.ReadByte();
                    if (b < 0)
                    {
                        // the only way this should happen is if someone truncates the file out from underneath us while we are reading backwards
                        throw new System.IO.IOException("Error reading from file at " + path);
                    }
                    if (b == '\n')
                    {
                        break;
                    }
                    fs.Position--;
                }
                byte[] bytes = new byte[fs.Length - fs.Position];
                fs.ReadExactly(bytes);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }
