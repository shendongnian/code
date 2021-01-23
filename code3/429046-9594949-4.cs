    class Question
    {
        public string Answer;
    }
        
    static void Main(string[] args)
    {
        var questions = new Question[] {
            new Question() { Answer = "Great" },
            new Question() { Answer = "Good" },
            new Question() { Answer = "Poor" },
            new Question() { Answer = "Good" },
            new Question() { Answer = "Great" },
            new Question() { Answer = "Sucks" }
        };
        var questionGroupsWithCount = from question in questions
                                      group question by question.Answer into questionGroup
                                      select new {
                                          QuestionCount = questionGroup.Count(),
                                          QuestionGroup = questionGroup
                                      };
        var mostCommonAnswerCount = questionGroupsWithCount.Max(item => item.QuestionCount);
        var mostCommonAnswers = from item in questionGroupsWithCount
                                where item.QuestionCount == mostCommonAnswerCount
                                select item.QuestionGroup.Key;
        
        foreach (var answer in mostCommonAnswers)
            Console.WriteLine("\"{0}\" was chosen {1:N0} time(s).", answer, mostCommonAnswerCount);
    }
