    public class RecordFactory
    {
        RecordBase ParseCsvRow(string[] columns)
        {
            const int typeDescriminatorColumn = 0;
            switch (columns[typeDescriminatorColumn])
            {
                case "RecordTypeA":
                    return new RecordTypeA(columns[1], columns[2], ...);
                case "RecordTypeB":
                    return new RecordTypeB(columns[1], columns[2], ...);
                default:
                    throw new InvalidOperationException("Unexpected descriminator: " + columns[typeDescriminatorColumn]);
            }
        }
    }
