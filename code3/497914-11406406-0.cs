    public interface IProblemRepository {
      IEnumerable<Problem> LoadProblems();
    }
    
    public class XmlProblemRepository : IProblemRepository {
      ...
    }
    
    public class InMemoryProblemRepository : IProblemRepository {
      private readonly IEnumerable<Problem> problems;
    
      public InMemoryProblemRepository(IEnumerable<Problem> problems) {
        this.problems = problems;
      }
    
      public IEnumerable<Problem> LoadProblems() {
        return problems;
      }
    }
    
    public class RandomProblemFactory {
      public IEnumerable<Problem> GenerateProblems(int count) {
        ...
      }
    }
