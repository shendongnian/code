    public class Research
    {
        private Collection<Research> prerequisites 
        public Collection<Research> Prerequisites 
        {
            get { return this.prerequisistes; }
        }
        public bool IsComplete { get; set; }
        public bool PrerequisitesMet()
        {
            return this.Prerequisites.All(r => r.IsComplete);
        }
    }
