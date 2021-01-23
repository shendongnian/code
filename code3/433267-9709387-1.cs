    private static List<Record> ConvertRecords(IEnumerable<string> lines)
    {
        return (from line in lines
                let split = line.Split('|')
                select new Record {
                    Name = split[0],
                    SomeValue = int.Parse(split[1]),
                    OrderNumber = int.Parse(split[2]);
                }).ToList();
        }
    }
