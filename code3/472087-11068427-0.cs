    XDocument x = XDocument.Parse("<Students> <student> <Detail Name=\"abc\" Class=\"1st Year\"> <add key=\"Main\" value=\"web\"/> <add key=\"Optional\" value=\"database\"/> </Detail> </student> </Students>");
    var attributes = x.Descendants("Detail")
                      .Elements()
                      .Attributes()
                      .Select(d => new { Name = d.Name, Value = d.Value }).ToArray();
    foreach (var attribute in attributes)
    {
         Console.WriteLine(string.Format("Name={0}, Value={1}", attribute.Name, attribute.Value));
    }
