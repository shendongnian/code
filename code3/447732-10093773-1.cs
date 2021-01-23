    XElement root = XElement.Load(file) // or .Parse(string)
    string html = root.Get("content:encoded", string.Empty).Replace("&nbsp", " ");
    XElement xdata = XElement.Parse(string.Format("<root>{0}</root>", html));
    XElement[] paras = xdata.GetElements("p").ToArray();
    string src = paras[1].Get("a/img/src", string.Empty);
