    var people = new List<Person>();
    foreach (string line in File.ReadAllLines("Input.txt"))
    {
        string[] parts = line.Split(',');
        people.Add(new Person()  {
            Age = int.Parse(parts[0]),
            MaritialStatus = parts[1] == "s" ? MaritalStatus.Single : MaritalStatus.Married,
            Gender = parts[2] == "m" ? Gender.Mail : Gender.Femail,
            District = int.Parse(parts[3])
        });
    }
