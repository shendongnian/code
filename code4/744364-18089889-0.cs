    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Id(x => x.Id);
            Map(x => x.Color);
            Map(x => x.Model);
            Map(x => x.Name);
            DiscriminateSubClassesOnColumn("Type");
        }
    }
