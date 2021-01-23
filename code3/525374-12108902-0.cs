    using System.Xml.Linq;
    var doc = XDocument.Load(@"path\to\file.xml");
    var result = doc.Element("result");
    foreach(var mail in result.Elements("email")) {
        Console.WriteLine("id: {0}\nsubject: {1}",
            (int)mail.Element("Id"),
            (string)mail.Element("Subject"));
    }
