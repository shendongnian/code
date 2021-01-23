    public class Question
        {
            public int ID { get; set; }
            public string QuestionText { get; set; }
            public List<string> AnswerTextList { get; set; }
        }
    var results = (from x in doc.Descendants("mchoice")
    
                               select new Question()
                               {
                                   ID = Convert.ToInt16(x.Element("ID")),
                                   QuestionText = x.Element("question").Value,
                                   AnswerTextList = (x.Elements("answer").Select(m => m.Value.ToString()).ToList())
                               }).ToList();
