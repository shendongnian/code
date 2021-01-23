    public class HouseRepository : EFRepository<House>
    {
        public override IQueryable<House> GetAll()
        {
            return DbContext.Set<House>().Include("DoorTypes");
        }
    }
