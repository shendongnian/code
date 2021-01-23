    namespace Stackover
    {
        using System;
        using System.Xml.Linq;
    
        class Program
        {
            private const string Xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <namespaceDocument xmlns=""http://www.namedspace/schemas"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.namedspace/schemas.xsd"">
    <educationSystem>
        <school>
            <name>Primary School</name>
            <students>
                <student id=""123456789"">
                    <name>Steve Jobs</name>
                    <otherElements>
                        <dataA>data</dataA>
                    </otherElements>
                </student>
                <student id=""987654"">
                    <name>Jony Ive</name>
                    <otherElements>
                        <dataB>data</dataB>
                    </otherElements>
                </student>
            </students>
        </school>
        <school>
            <name>High School</name>
            <students>
                <student id=""123456"">
                    <name>Bill Gates</name>
                    <otherElements>
                        <dataC>data</dataC>
                    </otherElements>
                </student>
                <student id=""987654"">
                    <name>Steve Ballmer</name>
                    <otherElements>
                        <dataD>data</dataD>
                    </otherElements>
                </student>
            </students>
        </school>
    </educationSystem>
    </namespaceDocument>";
    
            
            static void Main(string[] args)
            {
                var root = XElement.Parse(Xml);
                XNamespace ns = "http://www.namedspace/schemas";
                foreach(var school in root.Descendants(ns + "school")) // or root.Descendants().Where(e => e.Name.LocalName.Equals("school"));
                {
                    Console.WriteLine(school.Element(ns + "name").Value);
                    
                    foreach (var students in school.Elements(ns+ "students"))
                    {
                        
                        foreach (var student in students.Elements())
                        {
                            Console.WriteLine(student.Attribute("id"));
                            Console.WriteLine(student.Name); // Name = namespace + XName
                            Console.WriteLine(student.Name.LocalName); // no namespace
                        }
                    }
                }
            }
         
        }
       
    }
