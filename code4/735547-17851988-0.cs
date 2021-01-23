    public partial class Form1 : Form
    {
        private const int FetchTestData = 50;
        private const int TabCharLength = 5;
        public Form1()
        {
            InitializeComponent();
            //With this Fontsettings - 5 chars = 1 Tab - this changes with different fonts
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            var type = typeof(TestData);
            var list = GetTestData();
            var maxProperty = GetMaxProperty(type);
            maxProperty = FillToNext(maxProperty);
            var properties = GetProperties(type);
            for (var i = 0; i < FetchTestData; i++)
            {
                var data = list[i];
                foreach (var propertyInfo in properties)
                {
                    richTextBox1.AppendText(propertyInfo.Name);
                    var tabs = GetNumberOfTabs(maxProperty, propertyInfo.Name.Length);
                    for (var j = 0; j < tabs; j++)
                        richTextBox1.AppendText("\t");
                    richTextBox1.AppendText(Convert.ToString(propertyInfo.GetValue(data)));
                    richTextBox1.AppendText(Environment.NewLine);
                }
                if (i >= FetchTestData - 1) 
                    continue;
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("---------- NEXT DATA ----------");
                richTextBox1.AppendText(Environment.NewLine);
            }
        }
        private int GetNumberOfTabs(int maxLength, int textLength)
        {
            if ((maxLength % TabCharLength) != 0)
                maxLength = FillToNext(maxLength);
            var difLength = maxLength - textLength;
            return (int)(Math.Floor(Convert.ToDouble(difLength / TabCharLength)) + 1);
        }
        private int FillToNext(int maxLength)
        {
            return maxLength + (5 - (maxLength % TabCharLength));
        }
        private PropertyInfo[] GetProperties(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        private int GetMaxProperty(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            return (from x in GetProperties(type)
                    select x.Name.Length).Max();
        }
        private List<TestData> GetTestData()
        {
            var returnValue = new List<TestData>();
            for (int i = 0; i < FetchTestData; i++)
            {
                returnValue.Add(new TestData()
                {
                    ID = i,
                    Name = "NameValue " + i,
                    Description = "DescriptionValue " + i,
                    PropertyA = "PropertyAValue " + i,
                    PropertyB = "PropertyBValue " + i,
                    SomeReallyLongPropertyName = "RandomStuff... " + i
                });
            }
            return returnValue;
        }
    }
    public class TestData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public string SomeReallyLongPropertyName { get; set; }
    }
