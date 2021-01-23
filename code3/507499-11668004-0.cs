    using (StreamReader sr = new StreamReader(newFile))
    using (StreamWriter sw = new StreamWriter(projectFile, false, Encoding.UTF8))
    {
         while (sr.Peek() >= 0)
         {
             string s = sr.ReadLine();
             if (s.Contains("<Project ToolsVersion=\"4.0\""))
             {
                  s = s + Environment.NewLine + importProject;
             }
    ... and so on
