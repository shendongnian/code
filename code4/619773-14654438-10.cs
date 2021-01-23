    public class ApplicationService: IApplicationService
    {
        private readonly IEntityFrameworkRepo repo; 
        // dependency passed by constructor
        public ApplicationService(IEntityFrameworkRepo repo)
        {
             this.repo = repo;
        }
        
        // save to db when DTO is eligible
        public ApplicationDto Add(ApplicationDto dto)
        {
             // some business rule
             if(dto.Id > 0 && dto.Name.Contains(string.Empty)){
                  //add to dbcontext and commit
             }else{
                  throw new NotEligibleException();
             } 
        }   
    }
