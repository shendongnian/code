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
        public IEnumerable<Research> RequiredResearch(Player player)
        {
            if (player.CompletedResearch.Contains(this))
            {
                return new Research[0];
            } 
            else 
            {
                return new[] { this }.Concat(
                    this.Prerequisites.SelectMany(r => r.RequiredResearch(player)));
            }
        }
    }
