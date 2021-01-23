    public class Exam: IEquatable<Exam>
    {
        ...
        public bool Equals(Exam exam)
        {
            return exam.correct == correct && exam.possible == possible;
        }
        public override bool Equals(object obj)
        {
            Exam exam = obj as Exam;
            return Equals(exam);
        }
        public override int GetHashCode()
        {
            return correct.GetHashCode() ^ possible.GetHashCode();
        }
    }
