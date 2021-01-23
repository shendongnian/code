    XmlDocument doc = new XmlDocument();
    
    Questions qs = new Questions();
    doc.Load(string.Format(@"questions.xml"));
    XmlNodeList list = doc.SelectNodes("/questions/question");
    foreach (XmlNode node in list)
    {
            Question q = new Question(); // <--- Look here
            q.Text = node.SelectSingleNode("text").InnerText;
            q.Type = node.SelectSingleNode("type").InnerText;
            q.Name = node.SelectSingleNode("name").InnerText;
            XmlNodeList options = doc.SelectNodes("/questions/question/options");
            foreach (XmlNode option in options)
            {
                q.Option.Add(option.SelectSingleNode("option").InnerText);
            }
            load.Visible = false;
            qa.Visible = true;
            qs.Question.Add(q);
            
    }
    DisplayQuestion(qs); //<-- And here
