    XmlDocument xml = new XmlDocument();
    xml.Load("QA.xml");
    XmlNodeList xList = xml.SelectNodes("Main/QA");
    foreach (XmlNode xn in xList)
    {
        string Question = xn["question"].InnerText;
        if (Question == txtQuestion.Text)
        {
            XmlNodeList answerlist = xn.SelectNodes("./answer");
            foreach (XmlNode ans in answerlist
                .Cast<XmlNode>()
                .OrderBy(elem => Guid.NewGuid()))
            {
                Console.WriteLine(ans.InnerText);
            }
        }
    } 
