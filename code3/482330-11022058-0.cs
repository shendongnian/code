    public class FILENAMEMap : ClassMap<FILENAME>
    {
        public FILENAMEMap()
        {     
            Table("FILENAME");
            Id(x => x.Id).Column("WHO");
            Map(x => x.YN1).Column("YN1");
            Map(x => x.YN2).Column("YN2");
