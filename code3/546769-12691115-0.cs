      public static IEnumerable<string>  GetFiles(string path)
      {
            foreach (string s in Directory.GetFiles(path, "*.extension_here"))
            {
                  yield return s;
            }
 
            foreach (string s in Directory.GetDirectories(path))
            {
                  foreach (string s1 in GetFiles(s))
                  {
                        yield return s1;
                  }
            }
      }
