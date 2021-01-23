    public class PatientCategoryApiController : ApiController
    {
        private IEntityRepository<PatientCategory, short> m_Repository;
        public PatientCategoryApiController(IEntityRepository<PatientCategory, short> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("entitiesContext is null");
            m_Repository = repository;
        }
    }
