    public class QuestionAnswer
    {
        public string ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    var qa = doc.Descendants("tasks").Elements("task")
                .Where(x => x.Element("id").Value == id)
                .Select(x => new QuestionAnswer() 
                        {
                          ID = "2",
                          Question = x.Element("question").Value,
                          Answer = x.Element("answer").Value
                        });
