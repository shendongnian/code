    var select = new XElement("select");
    foreach (var group in groupedList)  {
       var subLevel = group.First();
       var optGroup = new XElement("optGroup", new XAttribute("label", subLevel.Name);
       optGroup.
       sb.Append(
       foreach (var item in group.Skip(1).ToList()) {
          optGroup.Add(new XElement("option", new XAttribute("value", item.RowKey), new XText(item.Name)));
       }
       select.Add(optGroup);
    }
    var result = select.ToString();
