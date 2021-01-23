    var values = new OrderedDictionary()
    {
        { "A", null },
        { "B", null },
        { "C", null },
        { "D", null },
        { "E", null },
    };
    var records = new List<CustomObject>
    {
        new CustomObject{ Id = 1, MyList = new List<string>(){ "A", "B" }},
        new CustomObject{ Id = 2, MyList = new List<string>(){ "C", "F" }},
        new CustomObject{ Id = 3, MyList = new List<string>(){ "G", "H" }}
    };
    records.RemoveAll(record => !record.MyList.Any(item => values.Contains(item)));
    foreach (var record in records)
    {
        Console.WriteLine("Id={0}, MyList={1}",
            record.Id, String.Join(", ", record.MyList.ToArray()));
    }
