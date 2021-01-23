     static void Main(string[] args)
        {
            var engine = new FileHelperEngine(typeof(MyRecord));
            MyRecord[] myRecords = engine.ReadFile("data.csv") as MyRecord[];
            var numbers = myRecords.Select(x => x.ColumnB);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
        [DelimitedRecord(",")] 
        public class MyRecord
        {
            public string ColumnA;
            [FieldConverter(typeof(ScientificNotationConverter))] 
            public double ColumnB;
            [FieldConverter(typeof(ScientificNotationConverter))] 
            public double ColumnC;
        }
        public class ScientificNotationConverter : ConverterBase
        {
            public override object StringToField(string @from)
            {
                return Double.Parse(@from, System.Globalization.NumberStyles.Float);
            }
        }
