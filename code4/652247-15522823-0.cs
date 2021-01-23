    public class TestService : BaseService, IDisposable
    {
        public TestService(IRepositoryProvider repositoryProvider)
        : base(repositoryProvider)
        {
        }
        public IRepository<Exam> Exams { get { return GetStandardRepo<Exam>(); } }
    
    }
