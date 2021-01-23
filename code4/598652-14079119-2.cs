    class Program
    {
        static void Main(string[] args)
        {
            string input =
                @"DateTime: 2012-12-09 17:00:18
    Command: ALTER INDEX [XPKAttribute] ON [FMC360Train_MSCRM].[MetadataSchema].[Attribute] REORGANIZE WITH (LOB_COMPACTION = ON)
    Comment: ObjectType: Table, IndexType: Clustered, ImageText: No, NewLOB: No, FileStream: No, AllowPageLocks: Yes, PageCount: 1336, Fragmentation: 10.1796
    Outcome: Succeeded
    Duration: 00:00:01
    DateTime: 2012-12-09 17:00:19
    
    DateTime: 2012-12-09 17:00:19
    Command: ALTER INDEX [XPKLocalizedLabel] ON [FMC360Train_MSCRM].[MetadataSchema].[LocalizedLabel] REORGANIZE WITH (LOB_COMPACTION = ON)
    Comment: ObjectType: Table, IndexType: Clustered, ImageText: No, NewLOB: Yes, FileStream: No, AllowPageLocks: Yes, PageCount: 2522, Fragmentation: 18.5964
    Outcome: Succeeded
    Duration: 00:00:01
    DateTime: 2012-12-09 17:00:20";
            var data = new Regex(@"^DateTime:\ (?<StartTime>[^\r]+)\r\nCommand: ALTER INDEX \[([^\]]+)\] ON (?<DBTableName>\[([^\]]+)\]\.\[([^\]]+)\]\.\[([^\]]+)\]) (?<Type>[^ ]+) ([^\r]+)\r\nComment:\ (?<Comment>[^\r]+)\r\nOutcome:\ (?<Outcome>[^\r]+)\r\nDuration:\ (?<Duration>[^\r]+)\r\nDateTime:\ (?<EndTime>[^\r]+)", RegexOptions.Multiline)
                .Matches(input).Cast<Match>().Select(m => new
                {
                    StartTime = m.Groups["StartTime"].Value,
                    DBTableName = m.Groups["DBTableName"].Value,
                    Type = m.Groups["Type"].Value,
                    Comment = m.Groups["Comment"].Value,
                    Outcome = m.Groups["Outcome"].Value,
                    Duration = m.Groups["Duration"].Value,
                    EndTime = m.Groups["EndTime"].Value
                });
            foreach (var datum in data)
            {
                Console.WriteLine("StartTime: {0}", datum.StartTime);
                Console.WriteLine("DBTableName: {0}", datum.DBTableName);
                Console.WriteLine("Type: {0}", datum.Type);
                Console.WriteLine("Comment: {0}", datum.Comment);
                Console.WriteLine("Outcome: {0}", datum.Outcome);
                Console.WriteLine("Duration: {0}", datum.Duration);
                Console.WriteLine("EndTime: {0}", datum.EndTime);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
