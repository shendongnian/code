    public class ICDEntry
    {
        public static ICDEntry CreateFrom(string line)
        {
            string[] values = line.Split(',');
            var entry = new ICDEntry();
            // assign values to properties:
            // if (values[0] == "\"Statement Date\"")
            //     entry.StatementDate = DateTime.Parse(values[1]);
            //     entry.IsSomething = values[11] == "\"\""
            return entry;
        }
            
        public DateTime? StatementDate { get; private set; }
        public string MobileSMS { get; private set; }
        public bool IsSomething { get; private set; }
    }
