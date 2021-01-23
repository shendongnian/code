    public class QuestionsContext
    {
        public IEnumerable<Question> GetQuestions()
        {
            var q = Builder<Question>.CreateListOfSize(5).Build().ToList();
            q.ForEach(x =>
            {
                x.ID = Guid.NewGuid();
                x.Answers = Builder<Answer>.CreateListOfSize(4)
                    .All().With(y => y.Question, x)
                    .Build().ToList();
            });
            return q;
        }
    }
