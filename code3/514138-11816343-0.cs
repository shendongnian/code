    Record1[] firstRecords = new[]
        {
            new Record1
                {
                    ID = Guid.NewGuid(),
                    Name = "John", Surname = "Doe"
                },
            new Record1
                {
                    ID = Guid.NewGuid(),
                    Name = "Jane", Surname = "Roe"
                }
        };
    Record2[] secondRecords = new[]
        {
            new Record2 { Age = 20, Sex = Sex.Male },
            new Record2 { Age = 20, Sex = Sex.Female }
        };
    var subjects = firstRecords
        .Select((first, index) =>
            {
                var second = secondRecords[index];
                var r = new
                    {
                        ID = first.ID,
                        Name = first.Name,
                        Surname = first.Surname,
                        Age = second.Age,
                        Sex = second.Sex
                    };
                return Mapper.DynamicMap<Subject>(r);
            })
        .ToArray();
