    public class SharedDetailsMapping : ClassMap<SharedDetails>
    {
        public SharedDetailsMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            HasMany(x => x.Foos)
               .Inverse();
        }
    }
