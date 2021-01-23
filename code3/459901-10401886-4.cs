    node.SelectNodes("options/option");            
---
    foreach (XmlNode node in list) {
        Question q = new Question(); // As RoXaS pointed out!
        ...
        XmlNodeList options = node.SelectNodes("options/option");
        foreach (XmlNode option in options) {
            q.Option.Add(option.InnerText);
        }
        ...
        qs.Question.Add(q);
    }
