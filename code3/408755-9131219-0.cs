    /// <summary>
    /// Each class that can generate a problem should accept a problem configuration
    /// </summary>
    public class BinaryProblem : IProblem
    {
        public BinaryProblem (ProblemConfiguration configuration)
	    {
            // sample code, this is where you generate your problem, based on the configuration of the problem
            X = new Random().Next(configuration.MaxValue + configuration.MinValue) - configuration.MinValue;
            Y = new Random().Next(configuration.MaxValue + configuration.MinValue) - configuration.MinValue;
            Answer = X + Y; 
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Answer { get; private set; }
    }
