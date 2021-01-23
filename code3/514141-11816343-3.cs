    var subjects = firstRecords
        .Select((first, index) =>
            {
                var second = secondRecords[index];
                var r = new Subject
                    {
                        ID = first.ID,
                        Name = first.Name,
                        Surname = first.Surname,
                        Age = second.Age,
                        Sex = second.Sex
                    };
                return r;
            })
        .ToArray();
