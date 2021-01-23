      var xdoc = XDocument.Load(@"C:\test.xml");
        foreach (var element in xdoc.Element("DiagReport").Elements().Elements())
        {
            if (element.Name == "Result")
            {
                string value = element.Value;
            }
        }
