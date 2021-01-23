    [DelimitedRecord(",")]
    public partial class MyClass
    {
        [FieldConverter(typeof(MyStringConverter))]
        [FieldQuoted('"')]
        public String Field1;
        [FieldConverter(typeof(MyStringConverter))]
        [FieldQuoted('"')]
        public String Field2;
    }      
    class Program
    {
        private static void Main(string[] args)
        {
            var engine = new FileHelperEngine<MyClass>();
            var myClass1 = new MyClass();
            myClass1.Field1 = "Dear Sir,\n Blah blah blah";
            myClass1.Field2 = "Yours sincerely,\n George";
            var output = engine.WriteString(new MyClass[]{myClass1});
            Assert.AreEqual(@"""Dear Sir, Blah blah blah"",""Yours sincerely, George""" + Environment.NewLine, output);
        }
    }
    public class MyStringConverter : ConverterBase
    {
        public override string FieldToString(object from)
        {
            string output = base.FieldToString(from);
            // remove any line breaks before outputting
            output = output.Replace("\n", "");
            output = output.Replace("\r", "");
            return output;
        }
        public override object StringToField(string from)
        {
            return from;
        }
    }
