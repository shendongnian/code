    class Program
    {
        static void Main(string[] args)
        {
            ProblemFactory problemFactory = new ProblemFactory();
            BinaryLevelConfiguration binaryLevelConfig = new BinaryLevelConfiguration();
            // register your factory functions
            problemFactory.RegisterProblem<BinaryProblem>((level) => new BinaryProblem(binaryLevelConfig.GetProblemConfiguration(level)));
            // consume them
            IProblem problem1 = problemFactory.GenerateProblem<BinaryProblem>(Level.Easy);
            IProblem problem2 = problemFactory.GenerateProblem<BinaryProblem>(Level.Hard);
        }
    }
