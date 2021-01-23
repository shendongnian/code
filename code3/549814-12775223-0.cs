        static void Main(string[] args)
        {
            List<string> questions = new List<string>();
            for (int i = 0; i < 10; i++)
                questions.Add("Question " + i);
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                int nextQuestion = r.Next(0, questions.Count);
                Console.WriteLine(questions[nextQuestion]);
                questions.RemoveAt(nextQuestion);
            }
        }
