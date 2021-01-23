    public static MyObject deserializeMyObject(){
    
    var xmlString = @"<?xml version=""1.0"" ?><MyObject property1=""foo"" property2=""bar"">
        <property3>value1</property3>
        <property3>value1</property3>
        <property3>value1</property3>
    </MyObject>";
    var xdoc=XDocument.Parse(xmlString);
    XmlSerializer _s = new XmlSerializer(typeof(MyObject));
    var foo= (MyObject)_s.Deserialize(xdoc.CreateReader()); 
    return foo;
    }
    
    //assumption about the structure of your MyObject class
    public class MyObject{
     [XmlAttribute("property1")]
    public string property1{get;set;}
    [XmlAttribute("property2")]
    public string property2 {get;set;}
     [XmlElement]
    public string[] property3 {get;set;}
    }
