    class Program
    {
        static void Main(string[] args)
        {
            ArrayOfDirective directives = new ArrayOfDirective();
            Directive directive = new Directive("RunSqlCar", "IgnoreColumn",
                    "These columns never match because IDs are different always.");
            directive.Columns.Add(new Column("value1"));
            directive.Columns.Add(new Column("value2"));
            directives.Directives.Add(directive);
            XmlSerializer ser = new XmlSerializer(typeof(ArrayOfDirective));
            using (StreamWriter sw = File.CreateText("c:\\directives_generated.xml"))
            {
                ser.Serialize(sw, directives);
            }
        }
    }
    [Serializable]
    public class ArrayOfDirective
    {
        public List<Directive> Directives { get; set; }
        public ArrayOfDirective()
        {
            Directives = new List<Directive>();
        }
    }
    [Serializable]
    public class Directive
    {
        public string TestCaseName { get; set; }
        public string Action { get; set; }
        public List<Column> Columns { get; set; }
        public string Description { get; set; }
        public Directive(string testCaseName, string action, string description)
        {
            TestCaseName = testCaseName;
            Action = action;
            Description = description;
            Columns = new List<Column>();
        }
        public Directive()
        {
        }
    }
    [Serializable]
    public class Column
    {
        public string ColumnName { get; set; }
        public Column(string columnName)
        {
            ColumnName = columnName;
        }
        public Column()
        {
        }
    }
