    public class SearchTarget : IEntity
    {
        public virtual String Name { get; set; }
        public virtual IList<Search_SearchTarget_Link> Searches { get; set; }
    }
    
    public class Search : IEntityComponent
    {
        public virtual IList<Search_SearchTarget_Link> Targets { get; set; }
    }
    public class Search_SearchTarget_Link : IEntity
    {
        public virtual Search search { get; set; }
        public virtual SearchTarget searchtarget { get; set; }
    }
    public partial class PoliceAssistance
    {
        public virtual Search SearchWithWarrant { get; set; }
        public virtual Search SearchWithoutWarrant { get; set; }
    }
