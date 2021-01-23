    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            HasMany(x => x.Photos)
                .Cascade.AllDeleteOrphan()
                .Component(c =>
                {
                    c.ParentReference(x => x.Parent);
                    c.Map(x => x.Name);
                    c.Map(x => x.Data);
                });
        }
    }
