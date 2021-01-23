    void AddDynamicContent(string path, Panel panelToAddContent)
    {
      DirectoryInfo di = new DirectoryInfo(path);
      if (di.Exists)
      {
        FileInfo[] fileInfos = di.GetFiles("*.xaml");
        foreach (FileInfo fi in fileInfos)
        {
          XmlReader xmlReader = XmlReader.Create(fi.FullName);
          FrameworkElement dynamicContent = (FrameworkElement)XamlReader.Load(xmlReader);
          panelToAddContent.Children.Add(dynamicContent);
        }
      }
    }
    ...
    AddDynamicContent(@"c:\temp\controls", myStackPanel);
