    interface IQuiz {
          public List<Question> getQuestions();
          public float scoreQuiz();
    }
    class Answer { string answer; }
    class Question { 
          List<Answer> potentialAnswers;
          Answer correctAnswer;
    }
    class SportsQuiz : IQuiz { }
    class PeopleQuiz : IQuiz { }
    class HistoryQuiz : IQuiz { }
