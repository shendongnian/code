    public void insertInitialList(List<EmployeeEmploy> finalList)
            {
                Debug.WriteLine("insertInitialList" + finalList.Count());
    
                XDocument doc = XDocument.Load(GlobalClass.GlobalUrl);
    
                var result = from element in doc.Descendants("Plist")
                             select element;
    
                foreach (var ele in result)
                {
                    ele.Add(from a in finalList
                            select new XElement("EmployeeFinance",
                                  new XElement("EmployeeEmploy_Id"),
                                  new XElement("EmpPersonal_Id"),
                                  new XElement("Employee_Number")));
                    doc.Save(GlobalClass.GlobalUrl);
                }
    
    
    
            }
