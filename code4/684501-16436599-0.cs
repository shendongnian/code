    Dictionary<String, String> dic = new Dictionary<String, String>();
    dic.Add("title", "Some Title");
    dic.Add("test", "a string");
    dic.Add("paragraph0", "some text");
    dic.Add("paragraph1", "some more text on a new line");
    dic.Add("another test", "a string");
    // -----
    XDocument newXDoc = new XDocument();
    newXDoc.Add(new XElement("document",
                  new XElement("title", dic["title"]),
    			  dic.Where((kvp)=>kvp.Key.StartsWith("paragraph")).Select((kvp)=>new XElement("paragraph", dic[kvp.Key]))));
    
    String s=newXDoc.ToString();
    Console.WriteLine(s);
