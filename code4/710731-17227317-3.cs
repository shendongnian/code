    var oldPersonList = new List<Person> { 
        new Person { Name = "Bill" }, 
        new Person { Name = "Bob" }
    };
    var newPersonList = new List<Person> {
        new Person { Name = "Bill" },
        new Person { Name = "Bobby" }
    };
    
    var diffList = oldPersonList.Zip(newPersonList, GetDifference)
        .Where(d => d.ChangedProperties.Any())
        .ToList();
