    namespace WindowsFormsApplication1
    {
        public class QuestionController
        {
            private static List<Question> _questions = new List<Question>();
    
            public static void LoadData(string path)
            {
                //Load Data from path->_questions
            }
    
            public static List<Question> GetQuestionsByDifficulty(int difficulty)
            {
                return _questions.Where(p => p.Difficulty == difficulty).ToList();
            }
        }
    }
