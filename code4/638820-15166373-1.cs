    // dictionary as a storage for data read from file
    var Employees = new Dictionary<int,Employee>();
    
    // file reading
    var file = File.Open("Input.txt", FileMode.Open);
    using (var reader = new StreamReader(file))
    {
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] fields = line.Split(';');
    
            var newEmployee = new Employee { Id = int.Parse(fields[0]), Name = fields[1], SupervisorId = int.Parse(fields[2]) };
            Employees.Add(newEmployee.Id, newEmployee);
        }
    }
    
    // filling Subordinates within every employee
    foreach (var emp in Employees.Values)
    {
        if (Employees.ContainsKey(emp.SupervisorId))
            Employees[emp.SupervisorId].Subordinates.Add(emp);
    }
    
    // taking first (root) employee by selecting the one with supervisorId == 0
    var first = Employees.Values.First(e => e.SupervisorId == 0);
    
    // XML generation
    var xml = first.ToXml();
