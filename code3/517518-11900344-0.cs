                var xmlSample = @"<DataGridColumnsHeader>
                                <ColumnHeaderText>Name</ColumnHeaderText>
                                <ColumnHeaderText>Country</ColumnHeaderText>
                                <ColumnHeaderText>Phone</ColumnHeaderText>
                              </DataGridColumns>";
            var counter = 0;
            var elementCount = XDocument.Load(new System.IO.StringReader(xmlSample)).XPathSelectElements("//ColumnHeaderText").Count();
            foreach (var element in XDocument.Load(new System.IO.StringReader(xmlSample)).XPathSelectElements("//ColumnHeaderText"))
            {
                dataGrid.Columns[counter].Header = element.Value;
                counter++;
            }
