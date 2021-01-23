    public class QuestionComparer : IEqualityComparer<Question>
    {
        public bool Equals(Question x, Question y)
        {
            return x.Question == y.Question; // assuming that it's a value type like ID (int)
        }
        public int GetHashCode(Employee obj)
        {
            return obj.Question.GetHashCode();
        }
    }
