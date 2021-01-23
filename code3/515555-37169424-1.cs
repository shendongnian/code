    namespace myapp.Web.OData.Controllers
    {
        public class SubsetDataController : ODataController
        {
            private readonly IWarehouseRepository<FullEntity> _fullRepository;
            private readonly IUserRepository _userRepository;
    
            public SubsetDataController(
                IWarehouseRepository<fullEntity> fullRepository,
                IUserRepository userRepository
                )
            {
                _fullRepository = fullRepository;
                _userRepository = userRepository;
            }
    
    public IQueryable<SubsetEntity> Get()
            {
                Object webHostHttpRequestContext = Request.Properties["MS_RequestContext"];
                System.Security.Claims.ClaimsPrincipal principal =
                    (System.Security.Claims.ClaimsPrincipal)
                        webHostHttpRequestContext.GetType()
                            .GetProperty("Principal")
                            .GetValue(webHostHttpRequestContext, null);
                if (!principal.Identity.IsAuthenticated)
                    throw new Exception("user is not authenticated cannot perform OData query");
    
                //do security in here
    
                //irrelevant but this just allows use of data by Word and Excel.
                if (Request.Headers.Accept.Count == 0)
                    Request.Headers.Add("Accept", "application/atom+xml");
    
                return _fullRepository.Query().Select( b=>
                        new SubsetDataListEntity
                        {
                            Id = b.Id,
                            bitofData = b.bitofData
                        }
              } //end of query
       } //end of class
