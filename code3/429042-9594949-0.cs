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
        var questionCounts = questionGroups.Select(questionGroup => questionGroup.Count());
        var mostCommonAnswerCount = questionCounts.Max();
        var mostCommonAnswers = from questionGroup in questionGroups
                                where questionGroup.Count() == mostCommonAnswerCount
                                select questionGroup.Key;
        
        foreach (var answer in mostCommonAnswers)
            Console.WriteLine("\"{0}\" was chosen {1:N0} time(s).", answer, mostCommonAnswerCount);
    }
