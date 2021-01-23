    public class CatMap : ClassMap<Cat>
    {
        public CatMap()
        {
            Table("cats");
            Id(x => x.Id);
        }
    }
