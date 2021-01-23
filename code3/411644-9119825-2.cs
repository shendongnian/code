    XElement root = XElement.Parse(@"
        <table>
          <column name=""Total"" size=""0"">
            <column name=""Users"" size=""0"" />
          </column>
          <column name=""Date"" size=""0"" />
          <column name=""Unique"" size=""0"">
            <column name=""Clicks"" size=""0"">
              <column name=""RC"" size=""0"" />
              <column name=""CB"" size=""0"" />
            </column>
          </column>
        </table>");
    List<List<XElement>> outerList = new List<List<XElement>>();
    IEnumerable<XElement> innerList = root.Elements();
    while (innerList.Any())
    {
        outerList.Add(innerList.Select(e => new XElement(e.Name, e.Attributes())).ToList());
        innerList = innerList.SelectMany(element => element.Elements()).ToList();
    }
