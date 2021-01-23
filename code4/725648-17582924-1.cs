    //somewhere in your class definition
    private readonly IRepositoryHelper<T> repo;
    private readonly IProjectCrewsByProjectSpecFactory pfactory;
    //constructor
    public MyClass(IRepositoryHelper<ProjectDGACrew> repo, IProjectCrewsByProjectSpecFactory pfactory)
    {
    this.repo = repo;
    this.pfactory=pfactory;
    }
    //method to be tested
    public DataSourceResult GetProjectBySpec(int projectId, int seasonId, int episodeId)
    {
                var spec = pfactory.Create(projectId, seasonId, episodeId);
                var personList = repo.GetList(spec).Select(p => new
                    {//big query...}).ToDataSourceResult();
                    return personList;
    }
