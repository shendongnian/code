    public class Section
    {
        internal Section(TabCollection tabColl, SectionCollection subSections)
        {
            // check for null, etc.
    
            // do whatever you need to do to finish construction
            tabColl.Parent = this;
            subSections.Parent = this;
        }
    }
    
    public class SectionFactory : ISectionFactory
    {
        public Section Create()
        {
            var tabs = new TabCollection();
            var subs = new SectionCollection();
    
            return new Section(tabs, subs);
        }
    }
