    class Person
    {
        [CsvColumn(Name = "ID", ...)]
        string Id { get; set; }
        [CsvColumn(Name = "First Name", ...)]
        string FirstName { get; set; }
        [CsvColumn(Name = "Last Name", ...)]
        string LastName { get; set; }
    }
