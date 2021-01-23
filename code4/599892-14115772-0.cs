    var Employee1 = new { ID = 5, Name = "Prashant" };
    var Employee2 = new { ID = 1, Name = "Tim" };
    var employees = new[] { Employee1, Employee2 };
    foreach (var employee in employees)
    {
        Console.WriteLine("ID:{0}, Name:{1}", employee.ID, employee.Name);
    }
    for (int i = 0; i < employees.Length; i++)
    {
        Console.WriteLine("ID:{0}, Name:{1}", employees[i].ID, employees[i].Name);
    }
