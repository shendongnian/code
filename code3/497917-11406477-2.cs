    public class MemoryRepositoryService : IService
    {
        private List<Problem> problemList = new List<Problem>();
    
        public IEnumerable<Problem> GetProblems()
        {
          return problemList;
        }
    
        public void Submit(IEnumerable<Problem> problems)
        {
          problemList.AddRange(problems.ToList());
        }
    }
