    public static class Student
    {
        public static int TestsTaken = 0;
        public string Name;
        public int DoQuiz(Quiz quiz, Answers answers)
        {
            TestsTaken++;
            // Some answers checking logic and grade returning
        }
    }
