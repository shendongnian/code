    public class Player
    {
        private Collection<Research> completedResearch
        public Collection<Research> CompletedResearch
        {
            get { return this.completedResearch; }
        }
    }
    public class Research
    {
        private Collection<Research> prerequisites 
        public Collection<Research> Prerequisites 
        {
            get { return this.prerequisistes; }
        }
        public bool PrerequisitesMet(Player player)
        {
            return this.Prerequisites.All(r => player.CompletedResearch.Contains(r))
        }
    }
