    string id = "2";
    var qa = doc.Descendants("tasks").Elements("task")
                           .Where(x => x.Element("id").Value == id).FirstOrDefault();
    if (qa != null)
    {
       var question = qa.Element("question").Value;
       var answer = qa.Element("answer").Value;
    }
