    XDocument doc = XDocument.Load("YOURXML.xml");
    var quiz = from elements in doc.Elements("quiz").Elements("problem")
               select elements;
    
    foreach (var item in quiz)
    {
    question = item.Element("question").Value;
                        a = item.Element("answerA").Value; 
                        b = item.Element("answerB").Value; 
                        c = item.Element("answerC").Value; 
                        d = item.Element("answerD").Value; 
                        correct = item.Element("correct").Value; 
     questions.Add(new Question(question, a, b, c, d, correct));
    }
