    ....
    foreach (var elem in doc.Document.Descendants("Profiles"))
    {
        foreach (var attr in elem.Attributes("Name"))
        {
               if (attr.Value.Equals(this.Name))
                   TempElem = elem;
        }
    }
    TempElem.Remove();
    ...
