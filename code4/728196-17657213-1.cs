    var doc = XElement.Load(fileName);
    var dic = doc
         .Descendants("Documentid")
         .ToDictionary(e => e.Value, 
                       e => e.Parent.Parent.Parent.Element("Documentcode").Value );
     // verify
     Console.WriteLine(dic["12"]);
     Console.WriteLine(dic["25"]);
