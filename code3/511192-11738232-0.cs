    var dict = new Dictionary<string, List<string>>();
    foreach (XmlNode items in diagramTables)
    {
      string pkTable = items["PKTABLE_NAME"].InnerText.Replace("_",@"\_");
      string fkTable = items["FKTABLE_NAME"].InnerText.Replace("_",@"\_");
      if (!dict.ContainsKey(pkTable))
      {
        dict.Add(pkTable, new List<string>());
      }
      if (!dict[pkTable].Contains(fkTable))
      {
          dict[pkTable].Add(fkTable);
      }
    }
    foreach(var kvp in dict)
    {
      sb.Append(kvp.Key);
      sb.Append(" got ");
      sb.AppendLine(String.Join("|", kvp.Value.ToArray()));
    }
