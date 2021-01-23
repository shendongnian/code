    public class ProjectRepository : IProjectRepository
    {
      MyModelDbContext context = MyModelDbContextSingleton.Instance;
      [...]
    
