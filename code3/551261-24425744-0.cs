    pivate static void AddFontsToRdlc(string fileName, string defaultFont)
    {
      if (!File.Exists(fileName))
      {
        // Report file does not exist
        return;
      }
      XmlDocument document = new XmlDocument();
      document.Load(fileName);
      string documentNamespace = document.DocumentElement.NamespaceURI;
      XmlNodeList nodes = document.GetElementsByTagName("TextRun");
      bool foundStyle = false;
      bool foundFontFamily = false;
      foreach (XmlNode node in nodes)
      {
        foundStyle = false;
        foundFontFamily = false;
        foreach (XmlNode childNode in node.ChildNodes)
        {
          if (childNode.Name == "Style")
          {
            foundStyle = true;
            foreach (XmlNode styleNode in childNode.ChildNodes)
            {
              if (styleNode.Name == "FontFamily")
              {
                // Change the font here if changing all fonts to the default font
                // Alternatively, specify what font should change to what font with a switch
                foundFontFamily = true;
                break;
              }
            }
            if (!foundFontFamily)
            {
              XmlElement fontElement = document.CreateElement("FontFamily", documentNamespace);
              fontElement.InnerText = defaultFont;
              childNode.AppendChild(fontElement);
            }
            break;
          }
        }
        if (!foundStyle)
        {
          XmlNode styleElement = document.CreateElement("Style", documentNamespace);
          XmlElement fontElement = document.CreateElement("FontFamily", documentNamespace);
          fontElement.InnerText = defaultFont;
          styleElement.AppendChild(fontElement);
          node.AppendChild(styleElement);
        }
      }
      document.Save(fileName);
    }
