    class Employee
    {
      public string Name { get; set; }
      public Guid Guid { get; set; }
    }
    // ...
    ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
    var guid1 = Guid.NewGuid();
    employees.Add(new Employee { Name = "Roman", Guid = guid1 });
    employees.Add(new Employee { Name = "Oleg", Guid = Guid.NewGuid() });
    var x = employees.First(e => e.Guid == guid1);
    var index = employees.IndexOf(x); // index = 0, as expected
    var result = employees.Remove(x); // result = true, as expected
