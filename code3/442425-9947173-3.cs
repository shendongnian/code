    public class TestClass
    {
        public List<TestLineItem> LineItems { get; set; }
        public TestClass()
        {
            LineItems = new List<TestLineItem>();
        }
    }
    public class TestLineItem
    {
        private string SanitizeText(string input)
        {
            return input.Replace(",", "")
                .Replace(".", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("'", "")
                .Replace("\"", "");
        }
        private string m_field1;
        private string m_field2;
        public string Field1 
        {
            get { return m_field1; }
            set { m_field1 = SanitizeText(value); }
        }
        public string Field2 
        {
            get { return m_field2; }
            set { m_field2 = SanitizeText(value); }
        }
        public decimal Field3 { get; set; }
        public TestLineItem() { }
        public TestLineItem(object field1, object field2, object field3)
        {
            m_field1 = (field1 ?? "").ToString();
            m_field2 = (field2 ?? "").ToString();
            if (field3 == null || field3.ToString() == "")
                Field3 = 0m;
            else
                Field3 = Convert.ToDecimal(field3.ToString());
        }
    }
