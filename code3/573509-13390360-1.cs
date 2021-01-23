    public static string ReadNT(BinaryReader stream)
    {
       StringBuilder utf8string = new StringBuilder();
       using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, false))
       {
           while ((char c = reader.Read()) != 0)
                utf8string.Append(c);
       }
       return utf8string.ToString();
    }
