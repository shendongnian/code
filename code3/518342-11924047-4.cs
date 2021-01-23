    namespace Your_Namespace 
    {
        public class PapersRepository 
        {
            public IEnumerable < QuestionPaper > GetQuestionPapers() 
            {
                return QuestionPapers.AsEnumerable();
            }
        }
    }
