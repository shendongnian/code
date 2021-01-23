    List<XObject> list = new List<XObject>();
    list.Add(new XText(obj.Value.ToString()));
    if (obj.Estimate) list.Add(new XAttribute("Estimate", obj.Estimate));
    XElement xElem = new XElement("Val", list.ToArray());
    xElem.Save(stream);
