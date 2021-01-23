     Assembly asmbly = Assembly.LoadFrom("this_is_in_another_place/texts.dll")
     
     ResourceDictionary dic;
     using (Stream s = asmbly.GetManifestResourceStream("Texts.en-GB.xaml"))
     {
        using (XmlReader reader = new XmlTextReader(s))
        {
            dic = (ResourceDictionary)XamlReader.Load(reader);
        }
     }
