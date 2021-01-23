        var uri = @"pack://application:,,,/YourProjectName;component/PathToDictionary/Strings.xaml";
        var resourceInfo = Application.GetResourceStream(uri);
        using (var xmlReader = new XmlTextReader(resourceInfo.Stream) { WhitespaceHandling = WhitespaceHandling.None})
        {                    
            var xamlReader = new System.Windows.Markup.XamlReader();                    
            dictionary = (ResourceDictionary)xamlReader.LoadAsync(xmlReader);
        }
