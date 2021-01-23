    XDocument employees = XDocument.Load(@"EmployeesActions.xml");
    XDocument contracts = XDocument.Load(@"Contracts.xml");
    XDocument sysTypes = XDocument.Load(@"Systype.xml");
    var result = employees.Descendants("Action")
                .Join(sysTypes.Descendants("systype"),
                    e => e.Element("Status").Value,
                    s => s.Element("ID").Value,
                    (e, s) => new
                    {
                        ID = e.Element("ID").Value,
                        ContractID = e.Element("ContractID").Value,
                        Status = s.Element("FieldName").Value
                    })
                .Where(empAction => !String.IsNullOrEmpty(empAction.Status))
                .OrderByDescending(empAction => empAction.ID)
                .Join(contracts.Descendants("Contract"),
                    e => e.ContractID,
                    c => c.Element("ID").Value,
                    (e, c) => new
                    {
                        ContractID = c.Element("ID").Value,
                        ContractNo = c.Element("ContractNo").Value,
                        Status = e.Status
                    });
