     XDocument doc = XDocument.Load(@"C:\Temp\Test.xml");
     XName name = XName.Get("INTEL", "http://www.TestWebsite.com/schema/data");
     var nodes = doc.Root.Descendants(name);
     foreach (var node in nodes)
     {
           Console.WriteLine(node.Value);
     }
     Console.ReadLine();
