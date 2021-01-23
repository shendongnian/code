    string xmlString = "<School><Student><Id>2</Id><Name>dummy</Name><Section>12</Section></Student><Student><Id>3</Id><Name>dummy</Name><Section>11</Section></Student></School>";
    	
    XDocument doc = new XDocument();
    //Check for empty string.
    if (!string.IsNullOrEmpty(xmlString))
    {
       doc = XDocument.Parse(xmlString);
    }
    List<Student> students = new List<Student>();
    //Check if xml has any elements 
    if(!string.IsNullOrEmpty(xmlString) && doc.Root.Elements().Any())
    {
    	students = doc.Descendants("Student").Select(d =>
    	new Student
    	 {
    	   id=d.Element("Id").Value,
    	  name=d.Element("Name").Value,
    	  section=d.Element("Section").Value
    				
         }).ToList();	
    }
    public class Student{public string id; public string name; public string section;}
