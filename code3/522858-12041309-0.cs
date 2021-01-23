    IEnumerable<QuizQuestion> questions =
        from step in doc.Descendants("step")
        from question in step.Descendants("question")
        select new QuizQuestion
        {
            StepId = int.Parse(step.Attribute("id").Value),
            QuestionId =  int.Parse(question.Attribute("id").Value),
            QuestionText = question.Element("text").Value,
            Answers = (from answer in question.Descendants("answer")
                        select new QuizAnswer
                        {
                            AnswerId = int.Parse(answer.Attribute("id").Value),
                            CorrectAnswer = int.Parse(answer.Attribute("value").Value),
                            AnswerText = answer.Value
                        }).ToList()
        };
