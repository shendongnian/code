    quizQuestions = (from step in data.Element("quiz").Elements("step")
                     from question in step.Elements("question")
                     orderby question.Attribute("id").Value
                     select new QuizQuestion()
                     {
                         StepId = Convert.ToInt32(step.Attribute("id").Value),
                         QuestionId = Convert.ToInt32(question.Attribute("id").Value),
                         QuestionText = question.Element("text").Value,
                         Answers = (from answer in question.Element("answers").Elements("answer")
                             select new QuizAnswer
                             {
                                 AnswerId = Convert.ToInt32(answer.Attribute("id").Value),
                                 AnswerText = answer.Value,
                                 CorrectAnswer = Convert.ToInt32(answer.Attribute("value").Value)
                             }).ToList()
                      }).ToList();
