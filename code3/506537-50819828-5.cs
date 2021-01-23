    public static byte[] ReadExactly(this System.IO.Stream stream, byte[] buffer)
    {
        int offset = 0;
        while (offset < count)
        {
            int read = stream.Read(buffer, offset, count - offset);
            if (read == 0)
                throw new System.IO.EndOfStreamException();
            offset += read;
        }
        System.Diagnostics.Debug.Assert(offset == count);
        return buffer;
    }
    public static string ReadLastLineFromUTF8EncodedFile(string path)
    {
        using (Stream fs = File.OpenRead(path))
        {
        byte b;
        fs.Position = fs.Length;
        while (fs.Position > 0)
        {
          fs.Position--;
          b = (byte)fs.ReadByte();
          if (b == '\n')
          {
            break;
          }
          fs.Position--;
        }
        byte[] bytes = new byte[fs.Length - fs.Position];
        fs.ReadExactly(bytes);
        }
        return Encoding.UTF8.GetString(bytes);
    }
