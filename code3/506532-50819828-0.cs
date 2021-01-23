    Stream fs = File.OpenRead(path);
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
    fs.Close();
    return Encoding.UTF8.GetString(bytes);
