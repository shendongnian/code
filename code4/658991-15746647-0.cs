    [DelimitedRecord(",")]
    public partial class MyClass
    {
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime Date;
        [FieldConverter(typeof(MyTimeConverter))]
        public DateTime Time1;
        [FieldConverter(typeof(MyTimeConverter))]
        public DateTime Time2;
        [FieldConverter(typeof(MyTimeConverter))]
        public DateTime Time3;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime Time4;
        [FieldDelimiter("|")] // ignore the rest of the fields for this example
        public string Optional3;
    }      
    class Program
    {
        private static void Main(string[] args)
        {
            var engine = new FileHelperEngine<MyClass>();
            var records = engine.ReadString(@"01/10/2013,06:00:00;00,06:09:40;08,00:09:40:09,01/10/2013,06:00:00;00,06:09:40;08,00:09:40:09,""January 9, 2013 - Dreams_01.mp4"",Aired,7CFB84BD-A5B6-43E8-82EC-E78E7219B1C7");
            Assert.AreEqual(records[0].Date, new DateTime(2013, 10, 1));
            Assert.AreEqual(records[0].Time1, DateTime.MinValue.Date.Add(new TimeSpan(0, 6, 0, 0)));
            Assert.AreEqual(records[0].Time2, DateTime.MinValue.Date.Add(new TimeSpan(0, 6, 9, 40, 08)));
            Assert.AreEqual(records[0].Time3, DateTime.MinValue.Date.Add(new TimeSpan(0, 0, 9, 40, 09)));
        }
    }
    public class MyTimeConverter : ConverterBase
    {
        public override string FieldToString(object from)
        {
            return base.FieldToString(from);
        }
        public override object StringToField(string from)
        {
            /// apply any logic to clear up the input here
            /// for instance, split the string at any ';' or ':'
            var parts = from
                .Split(';', ':')
                .Select(x => Convert.ToInt32(x))
                .ToList();
            // if it has three parts assume there are no milliseconds
            if (parts.Count == 3)
                return DateTime.MinValue.Date.Add(new TimeSpan(0, parts[0], parts[1], parts[3]));
            else if (parts.Count == 4) // if it has four parts include milliseconds
                return DateTime.MinValue.Date.Add(new TimeSpan(0, parts[0], parts[1], parts[2], parts[3]));
            throw new Exception("Unexpected format");
        }
    }
