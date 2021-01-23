    var xDocument = XDocument.Load("http://localhost/AnswerIt.xml");
    
    foreach (var element in xDocument.Descendants("category"))
    {
        var node = lstQuestions.Nodes.Add(element.Attribute("name").Value);
        foreach (var subElement in element.Elements("question"))
        {
            var subnode = node.Nodes.Add(subElement.Attribute("is").Value);
            foreach (var answer in subElement.Elements("answer"))
                subnode.Nodes.Add(answer.Attribute("couldbe")
                       .Value.Replace("\t", ""));
        }
    }
