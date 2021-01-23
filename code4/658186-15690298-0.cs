    public class RoleApiController : ApiController
    {
        private RoleService _roleService = new RoleService();
        
        public RoleUser GetRoleUser(int sectionID)
        {
            if (sectionID != null)
            {
                return _roleService.GetUsers(sectionID);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
