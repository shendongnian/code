    public class MyEntityMap: ClassMap<MyENtity>
    {
        public MyEntityMap()
        {
            Table("MyTable");
            Id(x => x.ID);
            Version(x => x.Timestamp);
            Map(x => x.PropA);
            Map(x => x.PropB);
        }
    }
