    var result = XElement.Load("data.xml").
                          Descendants("Action").
                          Where(x => x.Element("ContractID").Value == "2")
                          .Take(1).Select(y => new
                           {
                                id = y.Element("ID").Value,
                                empId = y.Element("EmployeeID").Value,
                                contractId = y.Element("EmployeeID").Value,
                                date = y.Element("Date").Value
                           });
