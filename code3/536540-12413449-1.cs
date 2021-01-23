    string xml = 
            @"<Root>
                <Table name=""testTable"">
                    <Row>
                        <Column name=""test01"" value=""2029"" />
                        <Column name=""test02"" value=""2029"" />
                    </Row>
                    <Row>
                        <Column name=""test01"" value=""2029"" />
                        <Column name=""test02"" value=""2029"" />
                    </Row>
                </Table>
                <Table name=""testTable2"">
                    <Row>
                        <Column name=""test01"" value=""2029"" />
                        <Column name=""test02"" value=""2029"" />
                    </Row>
                    <Row>
                        <Column name=""test01"" value=""2029"" />
                        <Column name=""test02"" value=""2029"" />
                    </Row>
                </Table>
            </Root>";
    XDocument xDoc = XDocument.Parse(xml);
    var table = xDoc
            .Descendants("Table")
            .Select(t => new
            {
                Name = t.Attribute("name").Value,
                Rows = t.Descendants("Row")
                        .Select(r=> r.Descendants("Column")
                                     .ToDictionary(c=>c.Attribute("name").Value,
                                                   c=>c.Attribute("value").Value))
                        .ToList()
            })
            .ToList();
