    public class TableAMap : ClassMap<TableA>
    {
        public TableAMap()
        {
            ...
            Map(x => x.Permission).CustomType(typeof(Permission)).Not.Nullable();
            ...
        } 
    }
