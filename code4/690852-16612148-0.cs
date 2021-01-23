            XDocument xelement = XDocument.Parse(xml);
            var query = from nm in xelement.Elements("EmployeeFinance")
                        where (int)nm.Element("EmpPersonal_Id") == 28407
                        select new
                        {
                            Amounts = nm.Element("Allowance-Grade")
                                                   .Elements("Amount")
                                                   .Select(
                                                   row =>
                                                       new {
                                                            id = row.Value
                                                       }
                                                   ).ToList()
                        };
            var x = query.ToList();
            foreach (var ele in x)
            {
                foreach(var a in ele.Amounts)
                    Console.WriteLine(a);
            }
