    public class Class3 : IXmlSerializable
    {
        public string Name;
        public Class1 User1 = new Class1 
        {
            StringA = "A String",
            StringB = "B String",
            StringC = "C String"
        };
        public Class2 User2 = new Class2
        {
            StringD = "D String",
            StringE = "E String",
            StringF = "F String"
        };
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("StringA", User1.StringA);
            writer.WriteElementString("StringB", User1.StringB);
            writer.WriteElementString("StringC", User1.StringC);
            writer.WriteElementString("StringD", User2.StringD);
            writer.WriteElementString("StringE", User2.StringE);
            writer.WriteElementString("StringF", User2.StringF);
        }
