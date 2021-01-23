    XElement root1 = XElement.Load(file1);
    XElement root = new XElement("ROOT",
        root1.Elements()
            .Select(o => new XElement(o.Name, o
                .Descendants()
                .Select(x =>
                {
                    List<XElement> list = new List<XElement>();
                    list.Add(new XElement(x.Name, x.HasElements ? "" : x.Value));
                    if (x.HasAttributes)
                        list.AddRange(x.Attributes()
                            .Select(a => new XElement(a.Name, a.Value))
                            );
                    return list;
                })
                ))
                .ToArray());
