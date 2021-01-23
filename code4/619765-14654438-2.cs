    public class ApplicationService: IApplicationService
    {
        private readonly IEntityFrameworkRepo repo; 
        // dependency passed by constructor
        public ApplicationService(IEntityFrameworkRepo repo)
        {
             this.repo = repo;
        }
    
        public ApplicationDto Add(ApplicationDto dto)
        {
             //add to dbcontext and commit
        }   
    }
