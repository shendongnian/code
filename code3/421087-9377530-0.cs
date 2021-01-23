    public class Test
    {
        public int Prop { get; set; }
        public DateTime TheDate { get; set; }
    }
    
    public class SubTest : Test
    {
        private string _customizedDate;
        public string CustomizedDate 
        { 
            get { return TheDate.ToString("yyyyMMdd"); }
            set 
            { 
                _customizedDate = value;
                TheDate = DateTime.ParseExact(_customizedDate, "yyyyMMdd", null); 
            }
        }
    
        public Test Convert()
        {
            return new Test() { Prop = this.Prop };
        }
    }
    // Serialize 
    XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    XmlAttributes attributes = new XmlAttributes();
    attributes.XmlIgnore = true;
    overrides.Add(typeof(Test), "TheDate", attributes);
    
    XmlSerializer xs = new XmlSerializer(typeof(SubTest), overrides);
    SubTest t = new SubTest() { Prop = 10, TheDate = DateTime.Now, CustomizedDate="20120221" };
    xs.Serialize(fs, t);
    
    // Deserialize
    XmlSerializer xs = new XmlSerializer(typeof(SubTest));
    SubTest t = (SubTest)xs.Deserialize(fs);
    Test test = t.Convert();
