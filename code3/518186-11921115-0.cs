    try
    {
        object ob = System.Windows.Markup.XamlReader.Load(xmlReader);//
        mycv = (Canvas)ob;
    }
        catch (System.Windows.Markup.XamlParseException ex)
    {
        mycv = new Canvas();
    }
