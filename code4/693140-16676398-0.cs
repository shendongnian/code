    public class Sheet {
        public long Id { get; set; }
        // more fields
        public virtual IList<Section> Sections { get; set; }
        public IEnumerable<Section> RootSections
        {
            get { return Sections.Where(sect => sect.ParentId == null); }
        }
    }
