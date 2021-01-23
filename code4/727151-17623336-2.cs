    public class Research
    {
        private Collection<Research> prerequisites 
        public Collection<Research> Prerequisites 
        {
            get { return this.prerequisistes; }
        }
        public bool IsComplete { get; set; }
        public IEnumerable<Research> RequiredResearch()
        {
            if (this.IsComplete)
            {
                return new Research[0];
            } 
            else 
            {
                return new[] { this }.Concat(
                    this.Prerequisites.SelectMany(r => r.RequiredResearch()));
            }
        }
    }
