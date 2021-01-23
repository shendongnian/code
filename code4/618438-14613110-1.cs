    public ProjectListViewModel(IProjectListServiceAgent sa)
    public interface IProjectListServiceAgent
    {
        GetProjectList(string userName, string password)
    }
    
    public SqlProjectListFetcher : IProjectListServiceAgent 
    {
       GetProjectList(string userName, string password)
       {
           //Fetch project list using direct SQL server access.
       }
    }
    public WebServiceProjectListFetcher : IProjectListServiceAgent 
    {
       GetProjectList(string userName, string password)
       {
           //Fetch project list using web service.
       }
    }
