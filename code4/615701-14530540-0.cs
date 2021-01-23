    XDocument xdoc = XDocument.Load(path_to_xml);
    var query = xdoc.Root.Element("Unformatted")
                    .Elements("Text")
                    .SkipWhile(t => !t.IsEmpty)
                    .SkipWhile(t => t.IsEmpty)
                    .Select(t => (string)t);
             
