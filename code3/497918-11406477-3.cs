    public class ProblemFactory
    {
      public static Problem GenerateRandom()
      {
        var x = random.Next(y, z);
        var y = random.Next(y, z);
    
        return new BinaryProblem(x, y);
      }
    }
