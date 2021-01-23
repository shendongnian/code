    doc.Root.Descendants("ChartData").ToList().ForEach(node =>
                    {
                        node.Element("ListName").Value = chartname;
                        node.Element("ViewName").Value = SelectedList;
                    });
