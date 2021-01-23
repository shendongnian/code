    private static void StackOverflowQuestion()
    {
        IProblem<int> problem1 = new IntProblem(2, 4);
        problem1.Response = 6;
        IProblem<decimal> problem2 = new DecimalProblem(5, 10);
        problem2.Response = .5M;
        Console.WriteLine("Problem 1 is correct: {0}", problem1.IsCorrect());
        Console.WriteLine("Problem 2 is correct: {0}", problem2.IsCorrect());
    }
