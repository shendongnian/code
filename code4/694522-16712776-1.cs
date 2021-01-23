    public class GroupRepository : AbstractRepository<Group, SurveyContext>
    {
        public GroupRepository(UnitOfWork<SurveyContext> unit)
            : base(unit)
        {
        }
    }
