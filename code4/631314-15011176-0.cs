    public class ControlMap : ClassMap<Control>
    {
        public ControlMap()
        {
            Table("Controls");
            Id(x => x.Id);
            Map(x => x.Type);
            HasMany(x => x.Properties).Table("ControlProperties")
                .AsMap<string>(index => index.Column("PropertyName").Type<string>(),
                               element => element.Column("PropertyValue").Type<string>())
                .Cascade.All(); 
        }
    }
