    list.Add(new { Name = 6, Age = 2 }); //OK
    list.Add(new { Age = 2, Name = 6 }); //compile error!
	var maxAge = list.Max(person => person.Age);
    var oldPerson = list.Where(person => person.Age == maxAge).First();
	Console.WriteLine(maxAge); //31
	Console.WriteLine(oldPerson.Name + ", " + oldPerson.Age); //1, 31
