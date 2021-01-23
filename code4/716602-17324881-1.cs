    PropertyInfo[] properties = newList.First().GetType().GetProperties();
    List<string> headerNames = properties.Select(prop => prop.Name).ToList();
    for (int i = 0; i < headerNames.Count; i++)
    {
        ws.Cell(1, i + 1).Value = headerNames[i];
    }
