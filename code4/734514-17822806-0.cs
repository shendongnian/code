    using System.Xml.Linq;
    
    var xml = XElement.Parse(reader["ScenarioData"].ToString());
    
    //assuming there can be multiple <step> elements
    var steps = xml.Element("Scenario").Element("Steps").Elements("Step");
    var url = steps.First().Attribute("Url").Value;
