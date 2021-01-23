        public virtual IList<ISection> Sections { get; set; }
        public virtual IEnumerable<IItem> SectionItems
        {
            get {
                return Sections.SelectMany(sect => sect.Items);
            }
        }
