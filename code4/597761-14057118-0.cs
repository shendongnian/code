    class Section
    {
        public string       Name;
        public List<Option> Options;
    
        public class Option
        {
            public Section MySection { get; private set; }
            public string Name;
            public string Value;
            public string Path
            {
                get { return string.Format("{0}.{1}={2}", this.MySection.Name, this.Name, this.Value); }
            }
            public Option(Section mySection)
            {
                this.MySection = mySection;
            }
        }
    }
