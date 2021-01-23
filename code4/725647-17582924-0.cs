    public interface IRepositoryHelper<ProjectDGACrew>
    {
      IList<ProjectDGACrew> GetList(IProjectCrewsByProjectSpecFactory spec);
    }
    
    public interface IProjectCrewsByProjectSpecFactory 
    {
     ProjectDGACrew Create(int projectId, int seasonId, int episodeId);
    }
