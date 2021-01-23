    namespace StackFun
    {
        using System.Collections.Generic;
        using System.Linq;
        using System.Xml.Linq;
    
        public class PeopleList
        {
            public List<Person> People { get; set; }
        }
    
        public class Person
        {
            public string Name { get; set; }
            public PeopleList Children { get; set; }
        }
    
        class Program
        {
            static IEnumerable<PeopleList> GetChildren(PeopleList parent, IEnumerable<XElement> children)
            {
                parent.People = new List<Person>();
                foreach (var child in children)
                {
                    var person = new Person
                    {
                        Name = ((XText)child.FirstNode).Value.Trim(new[] { ' ', '\r', '\n' }),
                    };
                    parent.People.Add(person);
                    foreach (var childrenOf in child.Elements("ol").SelectMany(BuildFromXml))
                    {
                        person.Children = childrenOf;
                    }
                }
                yield return parent;
    
            }
            static IEnumerable<PeopleList> BuildFromXml(XElement node)
            {
                return GetChildren(new PeopleList(), node.Elements("li"));
            }
    
            static void Main(string[] args)
            {
                const string xml = @"<ol>
                <li>Heather</li>
                <li>Channing</li>
                <li>Briana</li>
                <li>Amber</li>
                <li>Sabrina</li>
                <li>Jessica
                    <ol>
                        <li>Melody</li>
                        <li>Dakota</li>
                        <li>Sierra</li>
                        <li>Vandi</li>
                        <li>Crystal</li>
                        <li>Samantha</li>
                        <li>Autumn</li>
                        <li>Ruby</li>
                    </ol></li>
                <li>Taylor</li>
                <li>Tara</li>
                <li>Tammy</li>
                <li>Laura</li>
                <li>Shelly</li>
                <li>Shantelle</li>
                <li>Bob and Alice
                  <ol>
                    <li>Courtney</li>
                    <li>Misty</li>
                    <li>Jenny</li>
                    <li>Christa</li>
                    <li>Mindy</li>
                  </ol></li>
                <li>Noel</li>
                <li>Shelby</li>
            </ol>";
    
                var doc = XDocument.Parse(xml);
                var listOfPeople = BuildFromXml(doc.Root).ToList();
            }
        }
    }
