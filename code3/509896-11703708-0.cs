    public static void write_lines(List<string> thelines, string path)
    {
        //this.PS_filepath = path;
        using (StreamWriter writer = new StreamWriter(path, true))
        {
          foreach(string line in thelines)
          {
              writer.WriteLine(line);
          }
        }
    }
