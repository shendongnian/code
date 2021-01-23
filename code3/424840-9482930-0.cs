    using System.Xml;
    class A {
        public string Something { get; set; }
    }
    class B {
        public string SomethingDifferent { get; set; }
    }
    class Program {
        const string xml = @"
    <values>
      <value type='A'>
        <something>ABC</something>
      </value>
      <value type='B'>
        <something-different>ABC</something-different>
      </value>
    </values>
    ";
        static void Main(string[] args) {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            foreach (XmlNode node in doc.SelectNodes("/values/value")) {
                string type = node.Attributes["type"].Value;
                switch (type) { 
                case "A":
                    A a = new A();
                    foreach (XmlNode propertyNode in node.ChildNodes) {
                        switch (propertyNode.Name) {
                        case "something":
                            a.Something = propertyNode.InnerText;
                            break;
                        }
                    }
                    break;
                case "B":
                    // etc ...
                    break;
                }
            }
        }
    }
