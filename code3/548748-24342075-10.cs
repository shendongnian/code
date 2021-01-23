    public static string[] ReadAllLines(string path)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      if (path.Length == 0)
        throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
      else
        return File.InternalReadAllLines(path, Encoding.UTF8);
    }
    private static string[] InternalReadAllLines(string path, Encoding encoding)
    {
      List<string> list = new List<string>();
      using (StreamReader streamReader = new StreamReader(path, encoding))
      {
        string str;
        while ((str = streamReader.ReadLine()) != null)
          list.Add(str);
      }
      return list.ToArray();
    }
