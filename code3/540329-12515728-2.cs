    public class Question
        {
            public int ID { get; set; }
            public string QuestionText { get; set; }
            public List<Answer> AnswerList { get; set; }
        }
    
        public class Answer
        {
            public string Text { get; set; }
            public bool IsCorrect { get; set; }
        }
    var results = (from x in doc.Descendants("mchoice")
    		select new Question()
    		{
    			ID = Convert.ToInt16(x.Element("ID")),
    			QuestionText = x.Element("question").Value,
    			AnswerList = (x.Elements("answer").Select(m => new Answer
    			{
    				Text = m.Value,
    				IsCorrect = m.Attribute("correct") != null && m.Attribute("correct").Value == "yes"
    			}).ToList())
    		}).ToList();
