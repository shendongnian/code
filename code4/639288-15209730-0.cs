    private void AddKeyValue(object key, object value) {
      // load the resource dictionary
      var rd = new System.Windows.ResourceDictionary();
      rd.Source = new System.Uri("pack://application:,,,/YOURAssemblyName;component/EnglishResources.xaml", System.UriKind.RelativeOrAbsolute);
    
      // add the new key with value
      rd.Add(key, value);
          
      // now you can save the changed resource dictionary
      var settings = new System.Xml.XmlWriterSettings();
      settings.Indent = true;
      var writer = System.Xml.XmlWriter.Create(@"EnglishResources.xaml", settings);
      System.Windows.Markup.XamlWriter.Save(rd, writer);
    }
