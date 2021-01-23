    public class MyThingyMap : BsonClassMap<MyThingy>
    {
        public MyThingyMap()
        {
            // Use conventions to auto-map
            AutoMap(); 
            // Customize automapping for specific cases
            GetMemberMap(x => x.SomeProperty).SetElementName("sp"); 
            UnmapMember(x => x.SomePropertyToIgnore);
        }
    }
