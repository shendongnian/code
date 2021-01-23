    public static IEnumerable<Question> GetAll(XElement elm)
    {
        var allQA = new List<Question>();
        var mchoices = elm.Descendants("mchoice").ToList();
        foreach (var choice in mchoices)
        {
            var answers = choice.Descendants("answer").ToList();
            var qA = new Question { QuestionText = choice.Descendants("question").SingleOrDefault().Value };
            foreach (var answer in answers)
            {
                qA.Answers.Add(new Answer { Answer1 = answer.Value});
            }
            allQA.Add(qA);               
        }
        return allQA;
    } 
