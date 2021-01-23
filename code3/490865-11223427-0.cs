    string screenContentXml = XamlWriter.Save(ScreenContent );
    //Load it into a new object:
    StringReader stringReader = new StringReader(screenContentXml );
    XmlReader xmlReader = XmlReader.Create(stringReader);
    UIElement screenContentClone = (UIElement)XamlReader.Load(xmlReader);
        
