    public class GraphChild
    {
        public int ID { get; set; }
        public int GraphLookupId  { get; set; } //<<<<< add this an SET ONLY this
        public virtual GraphRoot Root { get; set; }
        public virtual GraphLookup Lookup { get; set; }
    }
