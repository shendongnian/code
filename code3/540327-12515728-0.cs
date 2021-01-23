        public class Question
        {
            public int ID { get; set; }
            public string QuestionText { get; set; }
            public Answer Answer { get; set; }
        }
    
        public class Answer
        {
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Answer4 { get; set; }
    
        }
    var results = (from x in doc.Descendants("mchoice")
                   let answers = x.Elements("answer")
                   select new Question()
                     {
                          ID = Convert.ToInt16(x.Element("ID")),
                          QuestionText = x.Element("question").Value,
                          Answer = new Answer
                            {
                                Answer1 = answers.First().Value,
                                Answer2 = answers.Skip(1).First().Value,
                                Answer3 = answers.Skip(2).First().Value,
                                Answer4 = answers.Last().Value
                             }
    
    
                      }).ToList();
