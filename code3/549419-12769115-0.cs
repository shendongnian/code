    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Items)
                .KeyColumn("Owner_id")
                .Inverse();
        }
    }
