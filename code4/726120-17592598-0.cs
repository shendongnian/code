        var array = stringData.Split(new[] { "============================" }, StringSplitOptions.RemoveEmptyEntries);
                var document = new XDocument(new XElement("Root"));
                foreach (var item in array)
                {
                    if(!item.Contains("<"))
                        continue;
                    var subDocument = XDocument.Parse("<Root>" + item.Substring(0, item.LastIndexOf('>') + 1) + "</Root>");
                    foreach (var element in subDocument.Root.Descendants("MAINELEMENT"))
                    {
                        document.Root.Add(element);
                    }
                }
                var table = new DataTable();
                table.Columns.Add("ELEMENT1");
                table.Columns.Add("ELEMENT2");
                table.Columns.Add("ELEMENT3");
                var rows =
                    document.Descendants("MAINELEMENT").Select(el =>
                                                                   {
                                                                       var row = table.NewRow();
                                                                       row["ELEMENT1"] = el.Element("ELEMENT1").Value;
                                                                       row["ELEMENT2"] = el.Element("ELEMENT2").Value;
                                                                       row["ELEMENT3"] = el.Element("ELEMENT3").Value;
                                                                       return row;
                                                                   });
                foreach (var row in rows)
                {
                    table.Rows.Add(row);
                }
    
                foreach (DataRow dataRow in table.Rows)
                {
                    Console.WriteLine("{0},{1},{2}", dataRow["ELEMENT1"], dataRow["ELEMENT2"], dataRow["ELEMENT3"]);
                }
