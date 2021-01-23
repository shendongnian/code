    class Question
    {
        public string Answer;
    }
        
    static void Main(string[] args)
    {
        var questions = new Question[] {
            new Question() { Answer = "Great" }
            // Add more Question instances for testing
        };
        var questionGroups = from question in questions
                             group question by question.Answer;
        var questionGroupsWithCount = from questionGroup in questionGroups
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
