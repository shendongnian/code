    class Questions
    {
        const int NUMBER_OF_QUESTIONS = 10;
        readonly List<string> questionsList;
        private bool[] avoidQuestions; // this is the "do-not-ask-question" list
        public Questions()
        {
            avoidQuestions = new bool[NUMBER_OF_QUESTIONS];
            questionsList = new List<string>
                                {
                                    "question1",
                                    "question2",
                                    "question3",
                                    "question4",
                                    "question5",
                                    "question6",
                                    "question7",
                                    "question8",
                                    "question9"
                                };            
        }
        public string GetQuestion()
        {
            Random rnd = new Random();
            int randomVal;
            // get a new question if this question is on the "do not ask question" list
            do
            {
                randomVal =  rnd.Next(0, NUMBER_OF_QUESTIONS -1);
            } while (avoidQuestions[randomVal]);
            // do not allow this question to be selected again
            avoidQuestions[randomVal] = true;
            // do not allow question before this one to be selected
            if (randomVal != 0)
            {
                avoidQuestions[randomVal - 1] = true;
            }
            // do not allow question after this one to be selected
            if (randomVal != NUMBER_OF_QUESTIONS - 1)
            {
                avoidQuestions[randomVal + 1] = true;
            }
            return questionsList[randomVal];
        }
    }
