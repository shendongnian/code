    //Assuming your(missing) root element is "root"
    XmlSerializer ser = new XmlSerializer(typeof(class_table[]),new XmlRootAttribute("root"));
    class_table[] obj = (class_table[])ser.Deserialize(new StringReader(xml));
    public class class_table
    {
        [XmlArrayItem("field_name")]
        public List<string> fields;
        [XmlArrayItem("property_name")]
        public List<string> properties;
        [XmlArrayItem("method_name")]
        public List<string> methods;
    }
