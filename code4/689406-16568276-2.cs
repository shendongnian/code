      // You need a dictionary to map the columns of the data into the property of the
      //class since they have different names.
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      dictionary.Add("EMPLOYEE NAME", "EmployeeName");
      dictionary.Add("EMPLOYEE ID", "EmployeeId");
      
      XDocument doc = XDocument.Load("C://data.xml");
      var ElementList = doc.Root.Elements();
      List<Employee> list = new List<Employee>();
      foreach (XElement item in listaElementi)
          {
             // We read the properties from the xml
             var properties = item.Descendants().Where(p => p.HasAttributes);
                Employee employee = new Employee();
             // Using reflection and the dictionary we set the property value
             foreach (var property in properties)
                {
                    var t = property.FirstAttribute.Value;
                    var s = property.Value;
                    employee.GetType().GetProperty(dictionary[t]).SetValue(employee,s);
                }
             list.Add(employee);
                
            }
