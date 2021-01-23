    class Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
    var rows = doc.Descendants("EmpInfo").Select(e => new Entity()
    {
        Name = e.Element("Name").Value,
        Age = Convert.ToInt32(e.Element("Age").Value),
        Salary = Convert.ToDecimal(e.Element("Salary").Value)
    });
