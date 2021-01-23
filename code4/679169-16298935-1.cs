    private class XmlDefinition
    {
        public string ROOT { get;set; }
        public string ROW { get;set; }
        public string[] COLS  { get;set; }
        public string EPATH { get;set; }
    }
    
    
    void Foo()
    {
      var employeeDefinition = new XmlDefinition 
      { 
        ROOT = "Employees", 
        ROW = "Employee", 
        COLS = new[] { "Name", "Address", "Department", "Salary" },
        EPATH = string.Format(@"{0}\employee.xml",Path.GetDirectoryName(Application.ExecutablePath))
      };
    
      SaveFirstXmlFile(employeeDefinition); //save employees
    
      var productDefinition = new XmlDefinition 
      { 
        ROOT = "Products", 
        ROW = "Product", 
        COLS = new[] { "Name", "Description", "Cost" },
        EPATH = string.Format(@"{0}\products.xml",Path.GetDirectoryName(Application.ExecutablePath))
      };
    
      SaveFirstXmlFile(productDefinition); //save products
    }
    public void SaveFirstXmlFile(AClassforSomeXMLFile definition)
    {
        XElement xdoc = new XElement(definition.ROOT);
        //Iterate for number of rows(elements of data)            
        for (int nodes = 1; nodes <= NUMBER_OF_NODES; nodes++)
        {
            var cols = from c in definition.COLS select new XElement(c, "Some Value");
            xdoc.Add(new XElement(definition.ROW, cols.ToArray()));
        } 
        xdoc.Save(definition.EPATH);
    }
