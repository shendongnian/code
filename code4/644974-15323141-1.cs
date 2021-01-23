       var rand = new Random();
       var quiz = XDocument.Load(path);
        _questions = quiz.Descendants("question")
            .Select(q => new Question()
            {
                ID = int.Parse(q.Attribute("id").Value),
                Difficulty = int.Parse(q.Attribute("difficulty").Value),
                QuestionText = q.Element("text").Value,
                Answers = q.Element("answers")
                    .Descendants()
                    .Select(a => a.Value)
                    .OrderBy(a => rand.Next()) // randomizing answers
                    .ToArray(),
                CorrectAnswer = q.Element("answers")
                    .Descendants()
                    .First(a => a.Name == "correctAnswer").Value // use value
            })
            .OrderBy(q => rand.Next()); // randomizing questions
