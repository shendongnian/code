    List<string> result = new List<string>();
    foreach(string filename in Directory.GetFiles("D:\\Temp", "*.wav"))
    {
       if (!filename.Contains("blablabla"))
          result.Add(filename);
    }
