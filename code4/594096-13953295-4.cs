    XElement quest = XElement.Parse(xmlData);
            var questionsData = from qn in quest.Descendants("Question")
                               select new Question
                               {
                                   idQuestion = int.Parse(qn.Element("idQuestion").Value),
                                   QuestionName = qn.Element("QuestionName").Value,
                                   CorrectAns = qn.Element("CorrectAns").Value,
                                   WrongAns1 = qn.Element("WrongAns1").Value,
                                   WrongAns2 = qn.Element("WrongAns2").Value,
                                   WrongAns3 = qn.Element("WrongAns3").Value
                               };
            var Questions = questionsData.ToList();
            var noofquestions = Questions.Count;
            //If you want any question with specific id, say '2'
            int idQuestion = 2;
            var question = Questions.Where(item => item.idQuestion == idQuestion).First();
