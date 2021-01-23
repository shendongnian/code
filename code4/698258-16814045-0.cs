    // Classes
    public class SearchTarget : IEntity {
        public virtual String Name { get; set; }
    }
    public partial class PoliceAssistance {
        public virtual Search SearchWithWarrant { get; set; }
        public virtual Search SearchWithoutWarrant { get; set; }
  
        public class Search : IEntity {
            public virtual int Id { get; set; }
            public virtual IList<SearchTarget> Targets { get; set; }
        }
    }
    // Mapping
    public class PoliceAssistanceMap : IAutoMappingOverride<PoliceAssistance> {
        public void Override(AutoMapping<PoliceAssistance> map) {
            map.References(x => x.SearchWithWarrant)
               .Cascade.All();
            map.References(x => x.SearchWithoutWarrant)
               .Cascade.All();
        }
    }
    public class SearchMap : IAutoMappingOverride<PoliceAssistance.Search> {
        public void Override(AutoMapping<PoliceAssistance.Search> mapping) {
            mapping.HasManyToMany(x => x.Targets);
        }
    }
