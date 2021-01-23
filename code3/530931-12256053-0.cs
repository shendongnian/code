    string fileType = ConfigurationManager.AppSettings[@"configPath"];
    string[] paths = fileType.Trim().Split(';');
    List<string> cleanPath = new List<string>();
     int x = 0;
     foreach (string s in paths)
     {
         cleanPath.Add(s.Trim());
     }
     foreach(string viewList in cleanPath)
     {
          x++;
          MessageBox.Show(x + ".)" +viewList);//I put x.) just to know whether it still has whitespace characters.
     }
