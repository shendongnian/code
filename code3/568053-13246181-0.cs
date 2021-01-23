    List<Teacher> _teacher = new List<Teacher>();
    List<Salary> _salary = new List<Salary>();
    
    //populate salaries for later used
    _salary.Add(new Salary { basic = "300", hra = "400", level = "1" });
    _salary.Add(new Salary { basic = "500", hra = "700", level = "2" });
    
    _teacher.Add(new Teacher { 
        name = "Teacher 1",
        age = "34",
        level = "1",
        basic = _salary.Single(p=>p.level == "1").basic, //set basic and hra based on teacher's level
        hra = _salary.Single(p=>p.level == "1").hra,
    });
    
    _teacher.Add(new Teacher
    {
        name = "Teacher 2",
        age = "47",
        level = "2",
        basic = _salary.Single(p => p.level == "2").basic, //set basic and hra based on teacher's level
        hra = _salary.Single(p => p.level == "2").hra,
    });
    
    foreach (Teacher t in _teacher)
        Console.WriteLine(t.name + ", "+t.age + ", " +t.basic + ", " + t.hra);
