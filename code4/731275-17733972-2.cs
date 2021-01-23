    XElement rootElement = XElement.Parse(string.Format("<element>{0}</element>", 
                                                 yourString.Replace("?TAG", "TAG")));
    var elements = rootElement.Elements();
    var yourResult = elements.Select(x => new TagsAndParams { Tag = x,
        Params = x.Attributes.Where(xa => xa.Name.LocalName.BeginsWith("param") });
