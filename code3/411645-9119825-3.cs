    XElement root = XElement.Parse(@"
        <doc>
          <column1>
            <column2 />
          </column1>
          <column3 />
          <column4>
            <column5>
              <column6 />
              <column7 />
            </column5>
          </column4>
        </doc>");
    List<List<XElement>> outerList = new List<List<XElement>>();
    List<XElement> innerList = root.Elements().ToList();
    while (innerList.Any())
    {
        outerList.Add(innerList);
        innerList = innerList.SelectMany(element => element.Elements()).ToList();
    }
