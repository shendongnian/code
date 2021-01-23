    class QuesionsAndAnswers
    {
        private double firstNumber;
        private double secondNumber;
        private double userAnswer;
        private double computerAnswer;
        private string operators;
        private bool answerCorrect;
        private bool enableDouble;
        private double[] listOfNumbers;
        private string[] listOfOperators;
        private Random randomizer;
        private static QuesionsAndAnswers qa;
        private QuesionsAndAnswers()
        {
            randomizer = new Random();
            listOfNumbers = new double[] { 1,2,3,4,5,6,7,8,9 };
            listOfOperators = new string[] { "+", "-", "*", "/" };
        }
        public static QuesionsAndAnswers getQuesionsandAnswersInstance()
        {
            if (qa == null)
                qa = new QuesionsAndAnswers();
             return qa;
        }
        public string generateQuestions()
        {
            string result = "";
            operators = listOfOperators[randomizer.Next(listOfOperators.Length)];
            firstNumber = listOfNumbers[randomizer.Next(listOfNumbers.Length)];
            secondNumber = listOfNumbers[randomizer.Next(listOfNumbers.Length)];
            if ((operators.Equals("/")) && (enableDouble == false))
            {
                while (firstNumber % secondNumber == 0)
                {
                    firstNumber = listOfNumbers[randomizer.Next(listOfNumbers.Length)];
                }
                result = firstNumber + operators + secondNumber;
            }
            else if (operators.Equals("-") && (firstNumber<secondNumber))
            {
                while (firstNumber > secondNumber)
                {
                    firstNumber = listOfNumbers[randomizer.Next(listOfNumbers.Length)];
                    secondNumber = listOfNumbers[randomizer.Next(listOfNumbers.Length)];
                }
                result = firstNumber + operators + secondNumber;
            }
            return result;
        }
        public void setDoubleAnswers(bool check)
        {
            enableDouble = check;
        }
    }
}
